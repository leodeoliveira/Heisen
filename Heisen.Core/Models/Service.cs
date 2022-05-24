using MongoDB.Bson;

namespace Heisen.Core.Models
{
    public class Service : ProductBase
    {
        public int PriceTableId { get; set; }
    }
}
