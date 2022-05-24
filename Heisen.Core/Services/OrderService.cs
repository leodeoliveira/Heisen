using Heisen.Core.Abstraction;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using Heisen.Core.Models;
using System.Linq;

namespace Heisen.Core
{
    public class OrderService : IOrderService
    {

        private readonly IMongoCollection<Order> _orders;
        private readonly IMovementService _movementService;
        private readonly IServiceService _serviceService;

        public OrderService(IConfiguration configuration, IUserService userService, IMovementService movementService, IServiceService serviceService)
        {
            DatabaseService dbService = new DatabaseService(configuration);
            MongoClient _dbClient = dbService.GetConnectionString();
            _orders = _dbClient.GetDatabase("heisendb").GetCollection<Order>("Orders");
            _movementService = movementService;
            _serviceService = serviceService;
        }

        public string Add(Order order)
        {
            try
            {
                order.Services = UpdateServicePriceByPriceTable(order);
                _orders.InsertOne(order);
                return "OK";
            }
            catch (Exception e)
            {
                return "Order not added. See more details: " + e.Message;
            }
        }

        private List<Service> UpdateServicePriceByPriceTable(Order order)
        {
            List<Service> newListService = new List<Service>();
            foreach (Service item in order.Services)
                newListService.Add(new Service()
                {
                    Name = item.Name,
                    Price = _serviceService.GetServicePriceByTable(item.Name, item.PriceTableId)
                });

            return newListService;
        }

        public string Cancel(int id)
        {
            Order order = _orders.Find(u => u.OrderId.Equals(id)).FirstOrDefault();
            order.Status = OrderStatusEnum.Cancelled;
            return UpdateStatus(order);
        }

        public List<Order> Get()
        {
            return _orders.AsQueryable().ToList<Order>();
        }

        public List<Order> GetByDate(DateTime date)
        {
            return _orders.Find(u => u.OrderDate.Equals(date)).ToList<Order>();
        }

        public Order GetById(int id)
        {
            return _orders.Find(u => u.OrderId.Equals(id)).FirstOrDefault();
        }

        public List<Order> GetByUser(int userId)
        {
            return _orders.Find(u => u.User.UserId.Equals(userId)).ToList<Order>();
        }

        public string CloseOrderAndSetMovements(Order order)
        {
            try
            { 
                UpdateStatus(order);
                SaveMovements(order);
                return "OK";
            }
            catch (Exception e)
            {
                return "Order not concluded. See more details: " + e.Message;
            }
        }

        private void SaveMovements(Order order)
        {
            AddServiceMovement(order);
            AddProductMovement(order);
            AddUserPartnetMovement(order);
        }

        private void AddUserPartnetMovement(Order order)
        {
            decimal totalOrderService = order.Services.Sum(s => s.Price);
            foreach (UserPartner partner in order.User.UserPartners)
            {
                decimal totalValue = (totalOrderService * partner.Percentage) / 100;
                Movement movement = new Movement()
                {
                    UserId = partner.UserId,
                    Order = order,
                    Total = totalValue,
                    MovementDate = DateTime.Now,
                    Type = MovementType.Comission
                };
                _movementService.Add(movement);
            }
        }

        private void AddProductMovement(Order order)
        {
            if (order.Products == null || order.Products.Count == 0)
                return;

            decimal totalOrderProduct = order.Products.Sum(s => s.Price);
            Movement movementProduct = new Movement()
            {
                UserId = order.User.UserId,
                Order = order,
                Total = (totalOrderProduct * 10) / 100,
                MovementDate = DateTime.Now,
                Type = MovementType.Products
            };
            _movementService.Add(movementProduct);
        }

        private void AddServiceMovement(Order order)
        {
            decimal totalOrderService = order.Services.Sum(s => s.Price);
            Movement movementService = new Movement()
            {
                UserId = order.User.UserId,
                Order = order,
                Total = (totalOrderService * order.User.Percentage) / 100,
                MovementDate = DateTime.Now,
                Type = MovementType.Services
            };
            _movementService.Add(movementService);
        }

        private string UpdateStatus(Order order)
        {
            try
            { 
                FilterDefinition<Order> filter = Builders<Order>.Filter.Where(u => u.OrderId.Equals(order.OrderId));
                var orderToUpdate = Builders<Order>.Update.Set(o => o.Status, order.Status);
                _orders.UpdateOne(filter, orderToUpdate);
                return "OK";
            }
            catch (Exception e)
            {
                return "Order not updated. See more details: " + e.Message;
            }
        }
    }
}
