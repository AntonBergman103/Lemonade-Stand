using LemonadeStand.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace LemonadeStand.Test
{
    public class NullValidationTest
    {
        [Fact]
        public void ValidateOrder_MissingRecipeName_AddErrorMessage()
        {
            //Arrange

            var orderModel = new OrderModel
            {
                RecipeName = "",
                FruitTypeName = "Apple",
                FruitQuantity = 1,
                Quantity = 1,
                PaidAmount = 10,
            };

            var testValidator = new NullValidation();

            //Act

            var errors = testValidator.ValidateOrder(orderModel);

            //Assert
           
            Assert.Contains("Please enter a recipe.", errors);
        }
    }
}
