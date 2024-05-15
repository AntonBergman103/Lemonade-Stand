using LemonadeStand.Application;
using LemonadeStand.Domain;
using System.Collections.Generic;
using Xunit;

namespace LemonadeStand.Application.Test
{
    public class FruitPressServiceTests
    {
       
   
        private readonly FruitPressService _service;

        public FruitPressServiceTests()
        {
           
           
            _service = new FruitPressService();
        }

      

        [Fact]
        public void ProduceOrder_WithValidInputs_CompletePurchaseWithResultSucceeded()
        {
            // Arrange
            Recipe recipe = new Recipe("Apple Lemonade", typeof(Apple), 10, 2.5m);

            List<IFruit> fruits = new List<IFruit> { new Apple(), new Apple(), new Apple() }; 

            OrderModel orderModel = new OrderModel
            {
                RecipeName = recipe.Name,
                FruitTypeName = typeof(Apple).AssemblyQualifiedName,
                FruitQuantity = 3,
                PaidAmount = 20,
                Quantity = 1
            };

            // Act
            var result = _service.Produce(recipe, fruits, orderModel.PaidAmount, orderModel.Quantity);

            // Assert
            Assert.True(result.Succeeded);
          
        }

        [Theory]
        [InlineData(12,2)]
        [InlineData(20, 10)]
        [InlineData(24,14 )]

        public void ProduceOrder_WithValidInputs_CompleteWithRightChangeBack(int moneyPaid, int expected)
        {
            // Arrange
            Recipe recipe = new Recipe("Apple Lemonade", typeof(Apple), 10, 2.5m);

            List<IFruit> fruits = new List<IFruit> { new Apple(), new Apple(), new Apple() };

            OrderModel orderModel = new OrderModel
            {
                RecipeName = recipe.Name,
                FruitTypeName = typeof(Apple).AssemblyQualifiedName,
                FruitQuantity = 3,
                PaidAmount = moneyPaid,
                Quantity = 1
            };

            // Act
            var result = _service.Produce(recipe, fruits, orderModel.PaidAmount, orderModel.Quantity);

            // Assert
            Assert.Equal(expected,  actual: result.ChangeBack);
        }

        [Fact]
        public void ProduceOrder_WithValidInputs_CompleteWithRightMessageBack()
        {
            Recipe recipe = new Recipe("Apple Lemonade", typeof(Apple), 10, 2.5m);

            List<IFruit> fruits = new List<IFruit> { new Apple(), new Apple(), new Apple() }; 

            OrderModel orderModel = new OrderModel
            {
                RecipeName = recipe.Name,
                FruitTypeName = typeof(Apple).AssemblyQualifiedName,
                FruitQuantity = 3,
                PaidAmount = 10,
                Quantity = 1
            };

            // Act
            var result = _service.Produce(recipe, fruits, orderModel.PaidAmount, orderModel.Quantity);

            // Assert
            Assert.Equal(expected:"Purchase completed!", actual: result.Message);
        }
        [Theory]
        [InlineData(12, 9.5)]
        [InlineData(20, 17.5)]
        [InlineData(24, 21.5)]
        [InlineData(5,2.5)]
        public void ProduceOrder_WithValidInputs_CompleteWithCorrectExcessFruit(int fruitQuantity,decimal expected)
        {
            Recipe recipe = new Recipe("Apple Lemonade", typeof(Apple), 10, 2.5m);

            List<IFruit> fruits = new List<IFruit>();
            for (int i = 0; i < fruitQuantity; i++)
            {
                fruits.Add(new Apple());
            }

            OrderModel orderModel = new OrderModel
            {
                RecipeName = recipe.Name,
                FruitTypeName = typeof(Apple).AssemblyQualifiedName,
                FruitQuantity = fruitQuantity,
                PaidAmount = 10,
                Quantity = 1
            };

            // Act
            var result = _service.Produce(recipe, fruits, orderModel.PaidAmount, orderModel.Quantity);

            // Assert
            Assert.Equal(expected, actual: result.ExcessFruit);
        }
    }
}
