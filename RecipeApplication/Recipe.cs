
namespace RecipeApplication
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    
    public partial class Recipe
    {
        public Recipe()
        {
            this.RecipeIngredients = new HashSet<RecipeIngredient>();
        }
    
        public int Id { get; set; }
        [DisplayName("Recipe Name")]
        public string Name { get; set; }
        [DisplayName("Category name")]
        public int RecipeCatId { get; set; }
        [DisplayName("Description")]
        public string RecipeDescription { get; set; }
        [DisplayName("Inactive Prep Time")]
        public int PrepTime { get; set; }
        [DisplayName("Active Cook Time")]
        public int CookTime { get; set; }
        public string Procedures { get; set; }
        [DisplayName("Cuisine Type")]
        public int CuisineTypeId { get; set; }
    
        public virtual RecipeCategory RecipeCategory { get; set; }
        public virtual CuisineType CuisineType { get; set; }
        public virtual ICollection<RecipeIngredient> RecipeIngredients { get; set; }
    }
}
