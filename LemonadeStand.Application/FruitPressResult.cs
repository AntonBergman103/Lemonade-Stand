using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand.Domain
{
    public class FruitPressResult
    {
        public bool Succeeded { get; set; }
        public string Message { get; set; }
        public decimal ChangeBack { get; set; }

        public decimal ExcessFruit { get; set; }
        public FruitPressResult(bool succeeded, string message, decimal changeback, decimal excessfruit)
        {
            Succeeded = succeeded;
            Message = message;
            ChangeBack = changeback;
            ExcessFruit = excessfruit;
        }
    }

}
