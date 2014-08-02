
namespace RecipeApplication
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    
    public partial class RecipeCategory
    {
        public RecipeCategory()
        {
            this.Recipes = new HashSet<Recipe>();
        }
    
        public int Id { get; set; }
        [DisplayName("Category Name")]
        public string CatName { get; set; }
        [DisplayName("Category Description")]
        public string CatDesc { get; set; }
    
        public virtual ICollection<Recipe> Recipes { get; set; }
    }
}
