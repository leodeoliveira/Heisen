using MongoDB.Bson;
using System;
using System.Collections.Generic;

namespace Heisen.Core.Models
{
    public class User
    {
        public ObjectId _id { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public List<UserPartner> UserPartners { get; set; }
        public decimal Percentage { get; set; }
        public string[] Privilegies { get; set; }
    }
}
