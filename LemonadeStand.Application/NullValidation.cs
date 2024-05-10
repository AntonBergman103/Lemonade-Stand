using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand.Application
{
    public class NullValidation
    {
        public List<string> ValidateOrder(OrderModel orderModel)
        {
            List<string> errors = new List<string>();

            if (string.IsNullOrEmpty(orderModel.RecipeName))
            {
                errors.Add("Please enter a recipe.");
            }

            if (string.IsNullOrEmpty(orderModel.FruitTypeName))
            {
                errors.Add("Please choose a fruit type.");
            }

            if (orderModel.FruitQuantity <= 0) 
            {
                errors.Add("Please enter a valid fruit quantity.");
            }

            if (orderModel.Quantity <= 0) 
            {
                errors.Add("Please enter the number of glasses.");
            }

            if (orderModel.PaidAmount < 0) 
            {
                errors.Add("Please enter a valid amount paid.");
            }

            return errors;
        }
    }
}

