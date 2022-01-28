using System;
using System.Collections.Generic;
using System.Text;
using Heisen.Core.Models;

namespace Heisen.Core.Abstraction
{
    public interface IUserService
    {
        List<User> Get();
    }
}
