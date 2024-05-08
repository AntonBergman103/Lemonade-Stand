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
            decimal totalCost = recipe.PricePerGlass * quantityGlass ;
            if (moneyPaid < totalCost)
            {
                return new FruitPressResult(false, "Not enough money for this purchase.", 0);
            }

            //kolla om frukten finns
            int fruitCount = 0;
            foreach (var fruit in fruits)
            {
                if (fruit.GetType() == recipe.AllowedFruit)
                {
                    fruitCount++;
                }
            }

            if (fruitCount < quantityGlass)
            {
                return new FruitPressResult(false, "Not enough fruit for the beverage or the wrong fruit", 0);
            }

            // om allt går igenom kolla om kunden får växel 
            decimal changeBack = moneyPaid - totalCost;



            return new FruitPressResult(true, "purchase completed!", changeBack);
        }
        
    }

}
