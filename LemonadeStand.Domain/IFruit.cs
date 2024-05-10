using System.Collections.ObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand.Domain
{

    //en mall för andra koddelar som beskriver en frukt
    public interface IFruit // interface  (ritning/kontrakt/mall)
    {
        string Name { get; }
        decimal Quantity { get; set; }
    }


}
