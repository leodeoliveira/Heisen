using Heisen.Core.Abstraction;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using Heisen.Core.Models;

namespace Heisen.Core
{
    public class DatabaseService
    {
        private const string CONNECTION_STRING = "HeisenAppCon";
        private readonly IConfiguration _configuration;
        public DatabaseService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public MongoClient GetConnectionString()
        {
            return new MongoClient(_configuration.GetConnectionString(CONNECTION_STRING));
        }
    }
}
