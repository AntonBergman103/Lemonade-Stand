﻿using System;
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
       public int PricePerGlass { get; }
        public decimal ConsumptionPerGlass { get; }



        
        public Recipe(string name, Type fruitType, int pricePerGlass, decimal consumptionPerGlass )
        {
            Name = name;
            AllowedFruit = fruitType;
            PricePerGlass = pricePerGlass;
            ConsumptionPerGlass = consumptionPerGlass;
            

           
        }
    }

}
