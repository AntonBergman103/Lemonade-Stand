using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LemonadeStand.Domain;

namespace LemonadeStand.Application.Interfaces
{
    public interface IFruitPressService
    {

        FruitPressResult Produce(IRecipe recipe, ICollection<IFruit>
             fruits, int moneyPaid, int orderedGlassQuantity);


    }


}
