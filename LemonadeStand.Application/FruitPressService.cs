using LemonadeStand.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;



namespace LemonadeStand.Application
{
    
    public class FruitPressService : IFruitPressService
    {
        public FruitPressResult Produce(IRecipe recipe, ICollection<IFruit> fruits, int moneyPaid, int quantityGlass)
        {
            List<string> errorMessages = new List<string>(); //istället för att kolla en och en samla alla errors i en lista

           
            decimal totalCost = recipe.PricePerGlass * quantityGlass;
           
            if (moneyPaid < totalCost)
            {
                errorMessages.Add($"Not enough money for this purchase.{quantityGlass} glasses cost {totalCost}kr in total ");
            }
           
            if (!fruits.Any(fruit => fruit.GetType() == recipe.AllowedFruit))
            {
                errorMessages.Add("Wrong fruit for that recipe. ");

            }

            // check the total quantity of the fruit
            decimal fruitCount = fruits.Where(fruit => fruit.GetType() == recipe.AllowedFruit)
                                       .Sum(fruit => fruit.Quantity);

            decimal totalFruitNeeded = recipe.ConsumptionPerGlass * quantityGlass;

           
            if (fruitCount < totalFruitNeeded)
            {
               errorMessages.Add($"Not enough fruit for the beverage. {quantityGlass} glasses require {totalFruitNeeded} units of fruit. ");

            }

            // If there are any errors, return them all
            if (errorMessages.Any())
            {
                return new FruitPressResult(false, string.Join(" ", errorMessages), 0, 0);
            }


            decimal changeBack = moneyPaid - totalCost;
            decimal excessFruit = fruitCount - totalFruitNeeded;

            return new FruitPressResult(true, "Purchase completed!", changeBack, excessFruit);
        }
    }


}
