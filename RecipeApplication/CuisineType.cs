
namespace RecipeApplication
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    
    public partial class CuisineType
    {
        public CuisineType()
        {
            this.Recipes = new HashSet<Recipe>();
        }
        [DisplayName("Cuisine Name")]
        public string Name { get; set; }
        [DisplayName("Cuisine Name")]
        public int CuisineTypeId { get; set; }
    
        public virtual ICollection<Recipe> Recipes { get; set; }
    }
}
