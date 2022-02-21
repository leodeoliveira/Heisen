using Heisen.Core.Abstraction;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using Heisen.Core.Models;

namespace Heisen.Core
{
    public class ProductService : IProductService
    {

        private readonly IMongoCollection<Product> _products;

        public ProductService(IConfiguration configuration)
        {
            DatabaseService dbService = new DatabaseService(configuration);
            MongoClient _dbClient = dbService.GetConnectionString();
            _products = _dbClient.GetDatabase("heisendb").GetCollection<Product>("Products");
        }

        public string Add(Product Product)
        {
            try
            {
                _products.InsertOne(Product);
                return "OK";
            }
            catch (Exception e)
            {

                return "Product not added. See more details: " + e.Message;
            }
            
        }

        public List<Product> Get()
        {
            var allProducts = _products.AsQueryable();
            return allProducts.ToList<Product>();
        }

        public string Update(Product Product)
        {

            try
            {
                _products.ReplaceOne(u => u.ProductId == Product.ProductId, Product);
                return "OK";
            }
            catch (Exception e)
            {

                return "Product not updated. See more details: " + e.Message;
            }
        }

        public Product GetById(int id)
        {
            Product Product = _products.Find(u => u.ProductId.Equals(id)).FirstOrDefault();
            return Product;
        }
    }
}
