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
    
    public partial class Ingredient
    {
        public Ingredient()
        {
            this.RecipeIngredients = new HashSet<RecipeIngredient>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public int IngredientTypeId { get; set; }
    
        public virtual IngredientType IngredientType { get; set; }
        public virtual ICollection<RecipeIngredient> RecipeIngredients { get; set; }
    }
}
