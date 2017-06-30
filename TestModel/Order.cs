using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestModel
{
    public class Order
    {
        public int OrderID { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
        public string Email { get; set; }
    }
}
