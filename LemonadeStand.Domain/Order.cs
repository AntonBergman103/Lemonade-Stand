using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand.Domain
{
    public class Order
    {
        public IRecipe RecipeOrdered { get; }
        public int Quantity { get; }
        public int PaidAmount { get; }

        public Order(IRecipe recipe, int quantity, int paidAmount) 
        {
            RecipeOrdered = recipe;
            Quantity = quantity;
            PaidAmount = paidAmount;
        }
    }
}
