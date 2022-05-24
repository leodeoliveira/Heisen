using MongoDB.Bson;

namespace Heisen.Core.Models
{
    public class PriceTable
    {
        public ObjectId _id { get; set; }
        public string Name { get; set; }
        public int PriceTableId { get; set; }
    }
}
