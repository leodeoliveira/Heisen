using MongoDB.Bson;

namespace Heisen.Core.Models
{
    public class Service
    {
        public ObjectId _id { get; set; }
        public int ServiceId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

    }
}
