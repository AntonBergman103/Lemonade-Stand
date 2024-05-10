using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand.Domain
{
    public class Fruit : IFruit // skapar en ny typ av objekt, vi kan skapa många frukter med olika namn
    {
        public string Name { get; }
        public decimal Quantity { get; set; }

        public Fruit(string name) // konstruktor
        {
            Name = name;
        }
    }
}
