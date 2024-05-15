using LemonadeStand.Domain;
using LemonadeStand.Application.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace LemonadeStand.Application
{
    public class FruitPressService : IFruitPressService
    {
        private readonly OrderValidator _orderValidator;

        public FruitPressResult Produce(IRecipe recipe, ICollection<IFruit> fruits, int moneyPaid, int quantityGlass)
        {
            var errors = _orderValidator.ValidateOrder(recipe, fruits, moneyPaid, quantityGlass);

            if (errors.Any())
            {
                return new FruitPressResult(false, string.Join(" ", errors), 0, 0);
            }
            decimal totalCost = recipe.PricePerGlass * quantityGlass;
            decimal totalFruitNeeded = recipe.ConsumptionPerGlass * quantityGlass;
            decimal fruitCount = fruits.Count(fruit => fruit.GetType() == recipe.AllowedFruit);
            decimal changeBack = moneyPaid - totalCost;
            decimal excessFruit = fruitCount - totalFruitNeeded;

            return new FruitPressResult(true, "Purchase completed!", changeBack, excessFruit);
        }
    }
}
