using Heisen.Core.Abstraction;
using Heisen.Core.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace WebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public JsonResult Get()
        {
            return new JsonResult(_orderService.Get());
        }

        [Route("Add")]
        [HttpPost]
        public JsonResult Add(Order order)
        {
            order.OrderDate = DateTime.Now;
            order.Status = OrderStatusEnum.Opened;
            return new JsonResult(_orderService.Add(order));
        }

        [Route("close")]
        [HttpPost]
        public JsonResult Close(int id)
        {
            Order order = _orderService.GetById(id);
            order.Status = OrderStatusEnum.Paid;
            return new JsonResult(_orderService.CloseOrderAndSetMovements(order));
        }

        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            return new JsonResult(_orderService.Cancel(id));
        }
    }
}
