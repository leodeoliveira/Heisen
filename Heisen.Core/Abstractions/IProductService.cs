using Heisen.Core.Models;
using System.Collections.Generic;

namespace Heisen.Core.Abstraction
{
    public interface IProductService
    {
        List<Product> Get();
        string Add(Product user);
        string Update(Product user);
        Product GetById(int id);
    }
}
