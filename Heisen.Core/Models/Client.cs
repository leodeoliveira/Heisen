using MongoDB.Bson;

namespace Heisen.Core.Models
{
    public class Client
    {
        public ObjectId _id { get; set; }
        public string Name { get; set; }
        public decimal Balance { get; set; }
    }
}
