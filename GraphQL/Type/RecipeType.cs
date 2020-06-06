using GraphQL.Types;
using RecipeWebApplication1.Entities;
using RecipeWebApplication1.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RecipeWebApplication1.GraphQL.Type
{
    public class RecipeType : ObjectGraphType<Recipe>
    {
        public RecipeType(StepRepository stepRepository)
        {
            Field(t => t.RecipeId);
            Field(t => t.Name);
            Field<ListGraphType<StepType>>(nameof(Recipe.Steps), resolve:
                context => stepRepository.GetByRecipeId(context.Source.RecipeId));

        }
    }
}
