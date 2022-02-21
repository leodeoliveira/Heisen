using Heisen.Core.Models;
using System;
using System.Collections.Generic;

namespace Heisen.Core.Abstraction
{
    public interface IOrderService
    {
        List<Order> Get();
        List<Order> GetByDate(DateTime date);
        List<Order> GetByUser(int userId);
        Order GetById(int id);
        string CloseOrderAndSetMovements(Order order);
        string Add(Order order);
        string Cancel(int id);
    }
}
