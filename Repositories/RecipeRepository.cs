using RecipeWebApplication1.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeWebApplication1.Repositories
{
    public class RecipeRepository
    {
        public Task<IEnumerable<Recipe>> GetAll()
        {
            return Task.FromResult<IEnumerable<Recipe>>(new List<Recipe>()
            {
                new Recipe() { RecipeId=1, Name = "Flammkuchen" }
                ,new Recipe() { RecipeId=2, Name = "Curryeintopf" }

            });
        }
        public async Task<Recipe> GetRecipeById(long recipeId)
        {
            var recipes = await GetAll();
            return recipes.FirstOrDefault(a => a.RecipeId == recipeId);
        }
    }
}
