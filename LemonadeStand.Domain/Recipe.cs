using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand.Domain
{
    public class Recipe : IRecipe
    {
        public string Name { get; }
        public Type AllowedFruit { get; }
        public decimal PricePerGlass { get; }

        public Recipe(string name, Type fruitType, decimal pricePerGlass)
        {
            Name = name;
            AllowedFruit = fruitType;
            PricePerGlass = pricePerGlass;
        }
    }

}
