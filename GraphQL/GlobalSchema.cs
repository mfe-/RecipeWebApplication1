using GraphQL;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeWebApplication1.GraphQL
{
    public class GlobalSchema : Schema
    {
        public GlobalSchema(IDependencyResolver dependencyResolver) : base(dependencyResolver)
        {
            Query = dependencyResolver.Resolve<GlobalQuery>();
        }
    }
}
