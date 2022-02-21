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

        private readonly IMongoCollection<User> _users;

        public UserService(IConfiguration configuration)
        {
            DatabaseService dbService = new DatabaseService(configuration);
            MongoClient _dbClient = dbService.GetConnectionString();
            _users = _dbClient.GetDatabase("heisendb").GetCollection<User>("Users");
        }

        public string Add(User user)
        {
            try
            {
                _users.InsertOne(user);
                return "OK";
            }
            catch (Exception e)
            {

                return "User not added. See more details: " + e.Message;
            }
            
        }

        public List<User> Get()
        {
            var allUsers = _users.AsQueryable();
            return allUsers.ToList<User>();
        }

        public string Update(User user)
        {

            try
            {
                FilterDefinition<User> filter = Builders<User>.Filter.Where(u => u.UserId.Equals(user.UserId));
                var userToUpdate = Builders<User>.Update.Set(u => u.Name, user.Name)
                                                        .Set(u => u.Phone, user.Phone)
                                                        .Set(u => u.UserPartners, user.UserPartners)
                                                        .Set(u => u.Percentage, user.Percentage)
                                                        .Set(u => u.isActive, user.isActive);

                _users.UpdateOne(filter, userToUpdate);
                return "OK";
            }
            catch (Exception e)
            {

                return "User not updated. See more details: " + e.Message;
            }
        }

        public User GetById(int id)
        {
            User user = _users.Find(u => u.UserId.Equals(id)).FirstOrDefault();
            return user;
        }

        public string Delete(int id)
        {
            User user = _users.Find(u => u.UserId.Equals(id)).FirstOrDefault();
            user.isActive = false;
            return Update(user);
        }
    }
}
