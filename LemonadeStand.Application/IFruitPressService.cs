using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand.Domain
{
    public interface IFruitPressService
    {

        FruitPressResult Produce(IRecipe recipe, ICollection<IFruit>
             fruits, int moneyPaid, int orderedGlassQuantity);


    }


}
