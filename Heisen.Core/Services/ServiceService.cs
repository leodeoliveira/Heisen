using Heisen.Core.Abstraction;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Linq;
using System.Collections.Generic;
using Heisen.Core.Models;

namespace Heisen.Core
{
    public class ServiceService : IServiceService
    {

        private readonly IMongoCollection<Service> _services;
        private readonly IPriceTableService _priceTableService;
        private readonly IUserService _userService;

        public ServiceService(IConfiguration configuration, IPriceTableService priceTableService, IUserService userService)
        {
            DatabaseService dbService = new DatabaseService(configuration);
            MongoClient _dbClient = dbService.GetConnectionString();
            _services = _dbClient.GetDatabase("heisendb").GetCollection<Service>("Services");
            _priceTableService = priceTableService;
            _userService = userService;
        }

        public string Add(Service service)
        {
            try
            {
                _services.InsertOne(service);
                return "OK";
            }
            catch (Exception e)
            {

                return "Service not added. See more details: " + e.Message;
            }
            
        }

        public List<Service> Get()
        {
            var allServices = _services.AsQueryable();
            return allServices.ToList<Service>();
        }

        public string Update(Service service)
        {

            try
            {
                _services.ReplaceOne(u => u._id == service._id, service);
                return "OK";
            }
            catch (Exception e)
            {

                return "Service not updated. See more details: " + e.Message;
            }
        }

        public Service GetById(int id)
        {
            Service Service = _services.Find(u => u._id.Equals(id)).FirstOrDefault();
            return Service;
        }

        public decimal GetServicePriceByTable(string name, int priceTableId)
        {
            Service Service = _services.Find(u => u.Name.Equals(name) && u.PriceTableId.Equals(priceTableId)).FirstOrDefault();
            return Service.Price;
        }

        public List<Service> GetServicesByBarberId(int barberId)
        {
            int priceTableId = _userService.GetById(barberId).PriceTableId;
            return GetServicesByPriceTableId(priceTableId);
        }

        private List<Service> GetServicesByPriceTableId(int priceTableId)
        {
            var serviceList = _services.AsQueryable().Where(s => s.PriceTableId.Equals(priceTableId));
            return serviceList.ToList<Service>();
        }
    }
}
