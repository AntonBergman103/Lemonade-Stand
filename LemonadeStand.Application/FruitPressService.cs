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
        private readonly OrderValidator _orderValidator;

        public FruitPressService()
        {
            _orderValidator = new OrderValidator();
        }

        public FruitPressResult Produce(IRecipe recipe, ICollection<IFruit> fruits, int moneyPaid, int quantityGlass)

        {
            var errors = _orderValidator.ValidateOrder(new OrderModel(), recipe, fruits, moneyPaid, quantityGlass);

            if (errors.Any())
            {
                return new FruitPressResult(false, string.Join(" ", errors), 0, 0);
            }

            decimal totalCost = recipe.PricePerGlass * quantityGlass;
            decimal fruitCount = 0;
            foreach (var fruit in fruits)
            {
                if (fruit.GetType() == recipe.AllowedFruit)
                {
                    fruitCount++;
                }
            }

            decimal totalFruitNeeded = recipe.ConsumptionPerGlass * quantityGlass;
            decimal changeBack = moneyPaid - totalCost;
            decimal excessFruit = fruitCount  - totalFruitNeeded;

            return new FruitPressResult(true, "Purchase completed!", changeBack, excessFruit);
        }
    }


}
