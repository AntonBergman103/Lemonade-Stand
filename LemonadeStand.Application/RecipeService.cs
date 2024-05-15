using LemonadeStand.Application.Interfaces;
using LemonadeStand.Domain;
using System.Collections.Generic;

namespace LemonadeStand.Application
{
    public class RecipeService : IRecipeService
    {
        private List<Recipe> _recipes = new List<Recipe>
        {
            new Recipe("Apple Lemonade", typeof(Apple), 10, 2.5m),
            new Recipe("Melon Lemonade", typeof(Melon), 12, 0.5m),
            new Recipe("Orange Lemonade", typeof(Orange), 9, 1m)
        };

        public List<Recipe> GetRecipes()
        {
            return _recipes;
        }
    }
}
