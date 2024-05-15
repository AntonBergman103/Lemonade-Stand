using LemonadeStand.Domain;
using System.Collections.Generic;

namespace LemonadeStand.Application.Interfaces
{
    public interface IRecipeService
    {
        List<Recipe> GetRecipes();
       
    }
}
