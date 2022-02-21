using Heisen.Core.Models;
using System.Collections.Generic;

namespace Heisen.Core.Abstraction
{
    public interface IMovementService
    {
        bool Add(Movement movement);
    }
}
