using MongoDB.Bson;

namespace Heisen.Core.Models
{
    public class ProductBase
    {
        public ObjectId _id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
