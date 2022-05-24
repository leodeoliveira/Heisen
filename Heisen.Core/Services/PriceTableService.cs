using Heisen.Core.Abstraction;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using Heisen.Core.Models;
using MongoDB.Bson;

namespace Heisen.Core
{
    public class PriceTableService : IPriceTableService
    {

        private readonly IMongoCollection<PriceTable> _tables;

        public PriceTableService(IConfiguration configuration)
        {
            DatabaseService dbService = new DatabaseService(configuration);
            MongoClient _dbClient = dbService.GetConnectionString();
            _tables = _dbClient.GetDatabase("heisendb").GetCollection<PriceTable>("PriceTable");
        }

        public List<PriceTable> Get()
        {
            var alltables = _tables.AsQueryable();
            return alltables.ToList();
        }

        public PriceTable GetById(int id)
        {
            return _tables.Find(u => u.PriceTableId.Equals(id)).FirstOrDefault();
        }
    }
}
