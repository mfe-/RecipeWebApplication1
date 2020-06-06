using RecipeWebApplication1.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeWebApplication1.Repositories
{
    public class StepRepository
    {
        public Task<IEnumerable<Step>> GetAll()
        {
            return Task.FromResult<IEnumerable<Step>>(new List<Step>()
            {
                new Step() { StepId=1, RecipeId=1, Description = "Räuchertofu + Zwiebeln schneiden" }
                ,new Step() { StepId=2, RecipeId=1, Description = "Für die Sauce alle zutaten vermischen: Hefe, Zwiebelpulber, Salz, Zitronensaft und Creme + evtl. Wasser" }
                ,new Step() { StepId=3, RecipeId=1, Description = "Auf den Flammteig Sauce geben" }
                ,new Step() { StepId=4, RecipeId=1, Description = "Nun den Räuchertofu und zwiebeln drauf gegeben" }
            });
        }
        public async Task<IEnumerable<Step>> GetByRecipeId(long recipeId)
        {
            var steps = await GetAll();
            return steps.Where(a => a.RecipeId == recipeId);
        }
    }
}
