using LemonadeStand.Application;
using LemonadeStand.Application.Interfaces;
using LemonadeStand.Domain;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using Xunit;

namespace LemonadeStand.Application.Test
{
    public class FruitPressServiceTests : IClassFixture<TestFixture>
    {
        private readonly IFruitPressService _service;

        public FruitPressServiceTests(TestFixture fixture)
        {
            _service = fixture.ServiceProvider.GetService<IFruitPressService>();
        }

        [Fact]
        public void ProduceOrder_WithValidInputs_CompletePurchaseWithResultSucceeded()
        {
            // Arrange
            Recipe recipe = new Recipe("Apple Lemonade", typeof(Apple), 10, 2.5m);
            List<IFruit> fruits = new List<IFruit> { new Apple(), new Apple(), new Apple() };

            // Act
            var result = _service.Produce(recipe, fruits, 20, 1);

            // Assert
            Assert.True(result.Succeeded);
        }

        [Theory]
        [InlineData(12, 2)]
        [InlineData(20, 10)]
        [InlineData(24, 14)]
        public void ProduceOrder_WithValidInputs_CompleteWithRightChangeBack(int moneyPaid, int expected)
        {
            // Arrange
            Recipe recipe = new Recipe("Apple Lemonade", typeof(Apple), 10, 2.5m);
            List<IFruit> fruits = new List<IFruit> { new Apple(), new Apple(), new Apple() };

            // Act
            var result = _service.Produce(recipe, fruits, moneyPaid, 1);

            // Assert
            Assert.Equal(expected, result.ChangeBack);
        }

        [Fact]
        public void ProduceOrder_WithValidInputs_CompleteWithRightMessageBack()
        {
            // Arrange
            Recipe recipe = new Recipe("Apple Lemonade", typeof(Apple), 10, 2.5m);
            List<IFruit> fruits = new List<IFruit> { new Apple(), new Apple(), new Apple() };

            // Act
            var result = _service.Produce(recipe, fruits, 10, 1);

            // Assert
            Assert.Equal("Purchase completed!", result.Message);
        }

        [Theory]
        [InlineData(12, 9.5)]
        [InlineData(20, 17.5)]
        [InlineData(24, 21.5)]
        [InlineData(5, 2.5)]
        public void ProduceOrder_WithValidInputs_CompleteWithCorrectExcessFruit(int fruitQuantity, decimal expected)
        {
            // Arrange
            Recipe recipe = new Recipe("Apple Lemonade", typeof(Apple), 10, 2.5m);
            List<IFruit> fruits = new List<IFruit>();
            for (int i = 0; i < fruitQuantity; i++)
            {
                fruits.Add(new Apple());
            }

            // Act
            var result = _service.Produce(recipe, fruits, 10, 1);

            // Assert
            Assert.Equal(expected, result.ExcessFruit);
        }
    }
}
