using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeWebApplication1.Entities
{
    public class Step
    {
        public long StepId { get; set; }
        public long RecipeId { get; set; }
        public int StepOrderId { get; set; }
        public string Description { get; set; }
        public IEnumerable<Ingredient> Ingredients { get; set; }
    }
}
