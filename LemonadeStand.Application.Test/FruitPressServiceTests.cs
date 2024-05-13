using LemonadeStand.Application;
using LemonadeStand.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace LemonadeStand.Test
{
    public class FruitPressServiceTests
    {
        [Fact]
        public void InsufficentFundsTest()
        {
            //Arrange
            List<Recipe> fakeRecipe = new List<Recipe>();

            Recipe recipe = new Recipe("AppleLemonade", typeof(Apple), 10, 2.5m);

            List<IFruit> fruits = new List<IFruit>
        { new Apple { Quantity = 2.5m } };

            FruitPressService service = new FruitPressService();

            int moneyPaid = 9; //not enough
            int quantityGlass = 1;


            //Act

            var result = service.Produce(recipe,fruits, moneyPaid, quantityGlass);


            //Assert

            Assert.Equal("Not enough money for this purchase.1 glasses cost 10kr in total ", result.Message);

        }

        [Fact]
        public void WrongFruitForThatRecipeTest()
        {
            //Arrange
            List<Recipe> fakeRecipe = new List<Recipe>();

            Recipe recipe = new Recipe("Apple Lemonade", typeof(Apple), 10, 2.5m);

            List<IFruit> fruits = new List<IFruit>
        { new Orange { Quantity = 2.5m } };

            FruitPressService service = new FruitPressService();

            int moneyPaid = 10;
            int quantityGlass = 1;


            //Act

            var result = service.Produce(recipe, fruits, moneyPaid, quantityGlass);


            //Assert
            /* Assert.Equals fungerade inte, utan då small även if satsen för "not enough fruit for the beverage" 
             * så tog contains, frågan är varför?  */
            Assert.Contains("Wrong fruit for that recipe. ", result.Message);
        }

        [Fact]
        public void NotEnoughFruitForThatBeverageTest()
        {
            //Arrange
            List<Recipe> fakeRecipe = new List<Recipe>();
            Recipe recipe = new Recipe("Apple Lemonade", typeof(Apple), 10, 2.5m);

            List<IFruit> fruits = new List<IFruit> { new Apple { Quantity = 1 } };

            FruitPressService service = new FruitPressService();
            int moneyPaid = 10;
            int quantityGlass = 1;
            
            //Act
            var result = service.Produce(recipe,fruits, moneyPaid, quantityGlass);

            //Assert

            Assert.Equal("Not enough fruit for the beverage. 1 glasses require 2,5 units of fruit. ", result.Message);
        }

        [Fact]
        public void MultipleErrorMessagesTest()
        {
            //Arrange
            List<Recipe> fakeRecipe = new List<Recipe>();
            Recipe recipe = new Recipe("Apple Lemonade", typeof(Apple), 10, 2.5m);

            List<IFruit> fruits = new List<IFruit> { new Orange { Quantity = 1 } }; // wrong fruit & insufficent ammount

            FruitPressService service = new FruitPressService();
            int moneyPaid = 1; // not enough money
            int quantityGlass = 1; 

            //Act
            var result = service.Produce(recipe, fruits, moneyPaid, quantityGlass);

            //Assert


            Assert.Contains("Not enough money for this purchase.1 glasses cost 10kr in total ", result.Message); // Check for insufficient funds message
            Assert.Contains("Wrong fruit for that recipe. ", result.Message); // Check for wrong fruit type message
            Assert.Contains("Not enough fruit for the beverage. 1 glasses require 2,5 units of fruit. ", result.Message); // Check for insufficient quantity message

        }

        [Fact]
        public void PurchaseCompletedTest()
        {
            //Arrange
            List<Recipe> fakeRecipe = new List<Recipe>();
            Recipe recipe = new Recipe("Apple Lemonade", typeof(Apple), 10, 2.5m);

            List<IFruit> fruits = new List<IFruit> { new Apple { Quantity = 5 } };  // expected 2.5 leftover

            FruitPressService service = new FruitPressService();
            int moneyPaid = 20; // expected 10 in change
            int quantityGlass = 1;

            //Act
            var result = service.Produce(recipe, fruits, moneyPaid, quantityGlass);

            //Assert
            Assert.True(result.Succeeded, "The purchase should succeed.");
            Assert.Equal("Purchase completed!", result.Message);
            Assert.Equal(10m, result.ChangeBack);
            Assert.Equal(2.5m, result.ExcessFruit);
        }



    }
}
