using MongoDB.Bson;
using System;
using System.Collections.Generic;

namespace Heisen.Core.Models
{
    public class Movement
    {
        public ObjectId _id { get; set; }   
        public int MovementId { get; set; }
        public int UserId { get; set; }
        public Order Order { get; set; }
        public DateTime MovementDate { get; set; }
        public decimal Total { get; set; }
        public MovementType Type { get; set; } 
    }

    public enum MovementType
    {
        Services = 1,
        Products = 2,
        Comission = 3
    }
}
