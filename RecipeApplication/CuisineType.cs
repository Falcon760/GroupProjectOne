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
    
    public partial class CuisineType
    {
        public CuisineType()
        {
            this.Recipes = new HashSet<Recipe>();
        }
    
        public string Name { get; set; }
        public int CuisineTypeId { get; set; }
    
        public virtual ICollection<Recipe> Recipes { get; set; }
    }
}
