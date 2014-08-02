
namespace RecipeApplication
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    
    public partial class Ingredient
    {
        public Ingredient()
        {
            this.RecipeIngredients = new HashSet<RecipeIngredient>();
        }
    
        public int Id { get; set; }
        [DisplayName("Ingredient Name")]
        public string Name { get; set; }
        public Nullable<int> IngredientTypeId { get; set; }
    
        public virtual IngredientType IngredientType { get; set; }
        public virtual ICollection<RecipeIngredient> RecipeIngredients { get; set; }
    }
}
