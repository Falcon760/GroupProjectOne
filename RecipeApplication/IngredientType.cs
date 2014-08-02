
namespace RecipeApplication
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    
    public partial class IngredientType
    {
        public IngredientType()
        {
            this.Ingredients = new HashSet<Ingredient>();
        }
    
        public int Id { get; set; }
        [DisplayName("Ingredient Type")]
        public string Name { get; set; }
    
        public virtual ICollection<Ingredient> Ingredients { get; set; }
    }
}
