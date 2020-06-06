using GraphQL.Types;
using RecipeWebApplication1.Entities;
using RecipeWebApplication1.GraphQL.Type;
using RecipeWebApplication1.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeWebApplication1.GraphQL
{
    public class GlobalQuery : ObjectGraphType
    {
        public GlobalQuery(IngredientRepository ingredientRepository, StepRepository stepRepository, RecipeRepository recipeRepository)
        {
            Field<ListGraphType<IngredientType>>("ingredients",
                resolve: context => ingredientRepository.GetAll());
            Field<ListGraphType<StepType>>("steps",
                resolve: context => stepRepository.GetAll());
            Field<ListGraphType<RecipeType>>("recipes",
                resolve: context => recipeRepository.GetAll());

            Field<RecipeType>(
                nameof(Recipe),
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IdGraphType>>
                {
                    Name = nameof(Recipe.RecipeId)
                }),
                resolve: (context) =>
                {
                    var recipeId = context.GetArgument<long>("recipeId");
                    return recipeRepository.GetRecipeById(recipeId);
                });
        }
    }
}
