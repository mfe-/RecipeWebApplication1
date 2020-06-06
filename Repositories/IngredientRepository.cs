using RecipeWebApplication1.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeWebApplication1.Repositories
{
    public class IngredientRepository
    {
        public Task<IEnumerable<Ingredient>> GetAll()
        {
            return Task.FromResult<IEnumerable<Ingredient>>(new List<Ingredient>()
            {
                new Ingredient() { Name = "Eis" }
            });
        }
    }
}
