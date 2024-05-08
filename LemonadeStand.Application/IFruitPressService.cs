using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand.Domain
{
    public interface IFruitPressService
    {
        // Metoden 'Produce' definieras i gränssnittet och ska implementeras av någon klass som använder detta gränssnitt.
        // Den tar emot en uppsättning parametrar och returnerar ett resultat av typen 'FruitPressResult'.

        FruitPressResult Produce(IRecipe recipe, ICollection<IFruit>
            fruits, int moneyPaid, int orderedGlassQuantity);



        // 'recipe' är en referens till ett recept som definierar hur lemonaden ska produceras.
        // 'fruits' är en samling av frukter som ska användas i produktionen av lemonad.
        // 'moneyPaid' är mängden pengar som kunden har betalat.
        // 'orderedGlassQuantity' är antalet glas lemonad som kunden har beställt.
    }


}
