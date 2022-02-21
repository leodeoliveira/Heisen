using Heisen.Core.Abstraction;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using Heisen.Core.Models;

namespace Heisen.Core
{
    public class ServiceService : IServiceService
    {

        private readonly IMongoCollection<Service> _services;

        public ServiceService(IConfiguration configuration)
        {
            DatabaseService dbService = new DatabaseService(configuration);
            MongoClient _dbClient = dbService.GetConnectionString();
            _services = _dbClient.GetDatabase("heisendb").GetCollection<Service>("Services");
        }

        public string Add(Service service)
        {
            try
            {
                _services.InsertOne(service);
                return "OK";
            }
            catch (Exception e)
            {

                return "Service not added. See more details: " + e.Message;
            }
            
        }

        public List<Service> Get()
        {
            var allServices = _services.AsQueryable();
            return allServices.ToList<Service>();
        }

        public string Update(Service service)
        {

            try
            {
                _services.ReplaceOne(u => u.ServiceId == service.ServiceId, service);
                return "OK";
            }
            catch (Exception e)
            {

                return "Service not updated. See more details: " + e.Message;
            }
        }

        public Service GetById(int id)
        {
            Service Service = _services.Find(u => u.ServiceId.Equals(id)).FirstOrDefault();
            return Service;
        }
    }
}
