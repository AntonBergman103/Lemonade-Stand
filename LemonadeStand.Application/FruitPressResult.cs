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

        public FruitPressResult(bool succeeded, string message, decimal changeback)
        {
            Succeeded = succeeded;
            Message = message;
            ChangeBack = changeback;
        }
    }

}
