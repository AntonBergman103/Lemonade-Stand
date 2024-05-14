using LemonadeStand.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LemonadeStand.Application
{
    public class OrderValidator
    {
        public List<string> ValidateOrder(OrderModel orderModel, IRecipe recipe, ICollection<IFruit> fruits, decimal moneyPaid, int quantityGlass)
        {
            List<string> errorMessages = new List<string>();

            decimal totalCost = recipe.PricePerGlass * quantityGlass;
            if (moneyPaid < totalCost)
            {
                errorMessages.Add($"Not enough money for this purchase. {quantityGlass} glasses cost {totalCost}kr in total.");
            }

            if (!fruits.Any(fruit => fruit.GetType() == recipe.AllowedFruit))
            {
                errorMessages.Add("Wrong fruit for that recipe.");
            }

            decimal fruitCount = 0;
            foreach (var fruit in fruits)
            {
                if (fruit.GetType() == recipe.AllowedFruit)
                {
                    fruitCount++;
                }
            }

            fruitCount = fruits.Count(fruit => fruit.GetType() == recipe.AllowedFruit);
            decimal totalFruitNeeded = recipe.ConsumptionPerGlass * quantityGlass;
            if (fruitCount < totalFruitNeeded)
            {
                errorMessages.Add($"Not enough fruit for the beverage. {quantityGlass} glasses require {totalFruitNeeded} units of fruit.");
            }

            return errorMessages;
        }
    }
}
