using LemonadeStand.Domain;

using System.Collections.Generic;
using System.Linq;

namespace LemonadeStand.Application
{
    public class OrderValidator
    {
        public List<string> ValidateOrder(IRecipe recipe, ICollection<IFruit> fruits, decimal moneyPaid, int quantityGlass)
        {
            List<string> errorMessages = new List<string>();

            InsufficentFundsForPurchase(recipe, moneyPaid, quantityGlass, errorMessages);
            WrongFruitForThatRecipe(recipe, fruits, errorMessages);

           InsufficentAmountOfFruits(recipe, fruits, quantityGlass, errorMessages);

            return (errorMessages);
        }

        private static void InsufficentFundsForPurchase(IRecipe recipe, decimal moneyPaid, int quantityGlass, List<string> errorMessages)
        {
            decimal totalCost = recipe.PricePerGlass * quantityGlass;
            if (moneyPaid < totalCost)
            {
                errorMessages.Add($"Not enough money for this purchase. {quantityGlass} glasses cost {totalCost}kr in total.");
            }
        }

        private static void WrongFruitForThatRecipe(IRecipe recipe, ICollection<IFruit> fruits, List<string> errorMessages)
        {
            if (!fruits.Any(fruit => fruit.GetType() == recipe.AllowedFruit))
            {
                errorMessages.Add("Wrong fruit for that recipe.");
            }
        }

        private static void InsufficentAmountOfFruits(IRecipe recipe, ICollection<IFruit> fruits, int quantityGlass, List<string> errorMessages)
        {
            decimal fruitCount = fruits.Count(fruit => fruit.GetType() == recipe.AllowedFruit);
            decimal totalFruitNeeded = recipe.ConsumptionPerGlass * quantityGlass;
            if (fruitCount < totalFruitNeeded)
            {
                errorMessages.Add($"Not enough fruit for the beverage. {quantityGlass} glasses require {totalFruitNeeded} units of fruit.");
            }

           
        }
    }
}
