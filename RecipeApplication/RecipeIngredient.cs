
namespace RecipeApplication
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    
    public partial class RecipeIngredient
    {
        [DisplayName("Recipe Name")]
        public Nullable<int> RecipeId { get; set; }
        [DisplayName("Ingredient Name")]
        public Nullable<int> IngredientId { get; set; }
        public string Measurement { get; set; }
        public int Id { get; set; }
    
        public virtual Ingredient Ingredient { get; set; }
        public virtual Recipe Recipe { get; set; }
    }
}
