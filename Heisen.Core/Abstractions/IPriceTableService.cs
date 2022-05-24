using Heisen.Core.Models;
using System.Collections.Generic;

namespace Heisen.Core.Abstraction
{
    public interface IPriceTableService
    {
        List<PriceTable> Get();
        PriceTable GetById(int id);
    }
}
