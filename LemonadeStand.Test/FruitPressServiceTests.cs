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

            Recipe recipeInsufficentFunds = new Recipe("AppleLemonade", typeof(Apple), 10, 2.5m);

            List<IFruit> fruits = new List<IFruit>
        { new Apple { Quantity = 2.5m } };

            FruitPressService service = new FruitPressService();

            int moneyPaid = 9; //not enough
            int quantityGlass = 1;




            //Act

            var result = service.Produce(recipeInsufficentFunds,fruits, moneyPaid, quantityGlass);


            //Assert

            Assert.Equal("Not enough money for this purchase. 1 glasses cost 10kr in total ", result.Message);

        }



    }
}
