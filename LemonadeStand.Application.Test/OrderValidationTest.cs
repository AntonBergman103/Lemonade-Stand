using LemonadeStand.Application;
using LemonadeStand.Domain;
using System.Collections.Generic;
using Xunit;

namespace LemonadeStand.Application.Test
{
   
    public class OrderValidationTest
    {
        private readonly OrderValidator _orderValidator;
        public OrderValidationTest() { _orderValidator = new OrderValidator(); }

        [Fact]
        public void ValidateOrder_WithInsufficientFunds_ReturnsError()
        {
            // Arrange
            Recipe recipe = new Recipe("Apple Lemonade", typeof(Apple), 10, 2.5m);

            List<IFruit> fruits = new List<IFruit>
            {
                new Apple(),
                new Apple(),
                new Apple()
            };

            OrderModel orderModel = new OrderModel
            {
                RecipeName = recipe.Name,
                FruitTypeName = typeof(Apple).AssemblyQualifiedName,
                FruitQuantity = 3,
                PaidAmount = 9,
                Quantity = 1
            };

            // Act
            var errors = _orderValidator.ValidateOrder(orderModel, recipe, fruits, orderModel.PaidAmount, orderModel.Quantity);


            // Assert
            Assert.Contains("Not enough money for this purchase. 1 glasses cost 10kr in total.", errors);
        }

        [Fact]
        public void ValidateOrder_WithWrongFruitForRecipe_ReturnsError()
        {
            // Arrange
            Recipe recipe = new Recipe("Apple Lemonade", typeof(Apple), 10, 2.5m);

            List<IFruit> fruits = new List<IFruit> { new Orange() };

            OrderModel orderModel = new OrderModel
            {
                RecipeName = recipe.Name,
                FruitTypeName = typeof(Orange).AssemblyQualifiedName,
                FruitQuantity = 2.5m,
                PaidAmount = 10,
                Quantity = 1
            };

            // Act
            var errors = _orderValidator.ValidateOrder(orderModel, recipe, fruits, orderModel.PaidAmount, orderModel.Quantity);
          

            // Assert
            Assert.Contains("Wrong fruit for that recipe.", errors);
        }

        [Fact]
        public void ValidateOrder_WithInsufficientFruit_ReturnsError()
        {
            // Arrange
            Recipe recipe = new Recipe("Apple Lemonade", typeof(Apple), 10, 2.5m);

            List<IFruit> fruits = new List<IFruit> { new Apple() };

            OrderModel orderModel = new OrderModel
            {
                RecipeName = recipe.Name,
                FruitTypeName = typeof(Apple).AssemblyQualifiedName,
                FruitQuantity = 1,
                PaidAmount = 10,
                Quantity = 1
            };

            // Act
            var errors = _orderValidator.ValidateOrder(orderModel, recipe, fruits, orderModel.PaidAmount, orderModel.Quantity);


            // Assert
            Assert.Contains("Not enough fruit for the beverage. 1 glasses require 2,5 units of fruit.", errors);
        }

        [Fact]
        public void ValidateOrder_WithMultipleErrors_ReturnsAllErrorMessages()
        {
            // Arrange
            Recipe recipe = new Recipe("Apple Lemonade", typeof(Apple), 10, 2.5m);

            List<IFruit> fruits = new List<IFruit> { new Orange() };

            OrderModel orderModel = new OrderModel
            {
                RecipeName = recipe.Name,
                FruitTypeName = typeof(Orange).AssemblyQualifiedName,
                FruitQuantity = 1,
                PaidAmount = 1,
                Quantity = 1
            };

            // Act
            var errors = _orderValidator.ValidateOrder(orderModel, recipe, fruits, orderModel.PaidAmount, orderModel.Quantity);


            // Assert
            Assert.Equal(expected: 3, actual: errors.Count);
        }

    }
}
