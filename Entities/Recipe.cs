using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeWebApplication1.Entities
{
    public class Recipe
    {
        public long RecipeId { get; set; }
        public string Name { get; set; }
        public IEnumerable<Step> Steps { get; set; }

    }
}
