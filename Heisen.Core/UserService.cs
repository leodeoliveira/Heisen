using Heisen.Core.Abstraction;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using Heisen.Core.Models;

namespace Heisen.Core
{
    public class UserService : IUserService
    {

        private readonly IConfiguration _configuration;
        public UserService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public List<User> Get()
        {
            MongoClient dbClient = new MongoClient(_configuration.GetConnectionString("HeisenAppCon"));
            var allUsers = dbClient.GetDatabase("heisendb").GetCollection<User>("Users").AsQueryable();
            return allUsers.ToList<User>();
        }
    }
}
