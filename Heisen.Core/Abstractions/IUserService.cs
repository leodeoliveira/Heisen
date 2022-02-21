using Heisen.Core.Models;
using System.Collections.Generic;

namespace Heisen.Core.Abstraction
{
    public interface IUserService
    {
        List<User> Get();
        string Add(User user);
        string Update(User user);
        string Delete(int id);
        User GetById(int id);
    }
}
