using MongoDB.Bson;
using System.Collections.Generic;

namespace Heisen.Core.Models
{
    public class Order
    {
        public ObjectId _id { get; set; }
        public int OrderId { get; set; }
        public string ClientName { get; set; }
        public Client Client { get; set; }
        public List<Service> Services { get; set; }
        public List<Product> Products { get; set; }
        public List<Beverage> Beverages { get; set; }
        public decimal Total { get; set; }
    }
}
