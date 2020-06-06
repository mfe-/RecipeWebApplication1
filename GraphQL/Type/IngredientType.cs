using GraphQL.Types;
using RecipeWebApplication1.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeWebApplication1.GraphQL.Type
{
    public class IngredientType : ObjectGraphType<Ingredient>
    {
        public IngredientType()
        {
            //map types long to the proper graphql types
            Field(t => t.IngredientId);
            Field(t => t.Name).Description("The name of the ingredient");
        }
    }
}
