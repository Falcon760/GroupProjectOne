//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RecipeApplication
{
    using System;
    using System.Collections.Generic;
    
    public partial class IngredientType
    {
        public IngredientType()
        {
            this.Ingredients = new HashSet<Ingredient>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
    
        public virtual ICollection<Ingredient> Ingredients { get; set; }
    }
}
