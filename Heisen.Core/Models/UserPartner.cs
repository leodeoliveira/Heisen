using MongoDB.Bson;

namespace Heisen.Core.Models
{
    public class UserPartner
    {
        public ObjectId _id { get; set; }
        public int UserId { get; set; }
        public decimal Percentage { get; set; }
    }
}
