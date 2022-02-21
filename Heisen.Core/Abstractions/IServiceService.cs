using Heisen.Core.Models;
using System.Collections.Generic;

namespace Heisen.Core.Abstraction
{
    public interface IServiceService
    {
        List<Service> Get();
        string Add(Service service);
        string Update(Service service);
        Service GetById(int id);
    }
}
