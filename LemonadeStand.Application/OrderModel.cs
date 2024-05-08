using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand.Application
{
    public class OrderModel
    {
        public string RecipeName { get; set; }
        public int Quantity { get; set; }
        public int PaidAmount { get; set; }
        public string FruitTypeName { get; set; }  // Stores the fruit type name for conversion to Type
    }

}
