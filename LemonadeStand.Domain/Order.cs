using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand.Domain
{
    public class Order
    {
        public IRecipe RecipeOrdered { get; set; }
        public int Quantity { get; set; }
        public int PaidAmount { get; set; }

        public Order(IRecipe recipe, int quantity, int paidAmount) 
        {
            RecipeOrdered = recipe;
            Quantity = quantity;
            PaidAmount = paidAmount;
        }
    }
}
