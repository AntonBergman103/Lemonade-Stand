using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand.Domain
{
    public interface IRecipe 
    {
        string Name { get; }
        Type AllowedFruit { get; }
        int PricePerGlass { get; }

        decimal ConsumptionPerGlass { get; }



        
    }

}
