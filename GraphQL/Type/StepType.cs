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
    public class StepType : ObjectGraphType<Step>
    {
        public StepType(IngredientRepository ingredientRepository)
        {
            Field(t => t.StepId);
            Field(t => t.RecipeId);
            Field(t => t.StepOrderId).Description("The order position of the current step in the list.");
            Field(t => t.Description);
            Field<ListGraphType<IngredientType>>(nameof(Step.Ingredients), resolve: context => ingredientRepository.GetAll());

        }
    }
}
