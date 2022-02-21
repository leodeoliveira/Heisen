using System;
using System.Collections.Generic;
using System.Text;

namespace Heisen.Core.Models
{
    public class Product : ProductBase
    {
        public int ProductId { get; set; }
        public decimal Percentage { get; set; }
        public int Quantity { get; set; }
    }
}
