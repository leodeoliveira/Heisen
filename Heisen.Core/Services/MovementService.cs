using Heisen.Core.Abstraction;
using Heisen.Core.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;

namespace Heisen.Core
{
    public class MovementService : IMovementService
    {
        private readonly IMongoCollection<Movement> _movements;

        public MovementService(IConfiguration configuration)
        {
            DatabaseService dbService = new DatabaseService(configuration);
            MongoClient _dbClient = dbService.GetConnectionString();
            _movements = _dbClient.GetDatabase("heisendb").GetCollection<Movement>("Movements");
        }

        public bool Add(Movement movement)
        {
            try
            {
                _movements.InsertOne(movement);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
