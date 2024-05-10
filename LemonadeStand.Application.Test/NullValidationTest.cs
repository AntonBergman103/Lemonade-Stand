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


        [Fact]
        public void ValidateOrder_MissingFruitTypeName_AddErrorMessage()
        {
            //Arrange

            var orderModel = new OrderModel
            {
                RecipeName = "AppleJuice",
                FruitTypeName = "",
                FruitQuantity = 1,
                Quantity = 1,
                PaidAmount = 10,
            };

            var testValidator = new NullValidation();

            //Act

            var errors = testValidator.ValidateOrder(orderModel);

            //Assert

            Assert.Contains("Please choose a fruit type.", errors);
        }

        [Fact]
        public void ValidateOrder_MissingFruitQuantity_AddErrorMessage()
        {
            //Arrange

            var orderModel = new OrderModel
            {
                RecipeName = "AppleJuice",
                FruitTypeName = "Apple",
                FruitQuantity = 0,
                Quantity = 1,
                PaidAmount = 10,
            };

            var testValidator = new NullValidation();

            //Act

            var errors = testValidator.ValidateOrder(orderModel);

            //Assert

            Assert.Contains("Please enter a valid fruit quantity.", errors);
        }

        [Fact]
        public void ValidateOrder_MissingQuantity_AddErrorMessage()
        {
            //Arrange

            var orderModel = new OrderModel
            {
                RecipeName = "AppleJuice",
                FruitTypeName = "Apple",
                FruitQuantity = 1,
                Quantity = 0,
                PaidAmount = 10,
            };

            var testValidator = new NullValidation();

            //Act

            var errors = testValidator.ValidateOrder(orderModel);

            //Assert

            Assert.Contains("Please enter the number of glasses.", errors);
        }

        [Fact]
        public void ValidateOrder_MissingPaidAmount_AddErrorMessage()
        {
            //Arrange

            var orderModel = new OrderModel
            {
                RecipeName = "AppleJuice",
                FruitTypeName = "Apple",
                FruitQuantity = 1,
                Quantity = 1,
                PaidAmount = 0,
            };

            var testValidator = new NullValidation();

            //Act

            var errors = testValidator.ValidateOrder(orderModel);

            //Assert

            Assert.Contains("Please enter a valid amount paid.", errors);
        }
    }
}
