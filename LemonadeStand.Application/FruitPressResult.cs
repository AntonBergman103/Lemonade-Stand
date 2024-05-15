using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand.Application.Interfaces
{
    public class FruitPressResult
    {
        public bool Succeeded { get; }
        public string Message { get;  }
        public decimal ChangeBack { get; }

        public decimal ExcessFruit { get; }
        public FruitPressResult(bool succeeded, string message, decimal changeback, decimal excessfruit)
        {
            Succeeded = succeeded;
            Message = message;
            ChangeBack = changeback;
            ExcessFruit = excessfruit;
        }
    }

}
