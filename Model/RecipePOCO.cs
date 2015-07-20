using System;
using System.Collections.Generic;
using OnlineCookbook.Model.Common;


namespace OnlineCookbook.Model
{
    public partial class RecipePOCO : IRecipe
    {
         public RecipePOCO()
        {
            this.Comments = new List<IComment>();
            this.Favourites = new List<IFavourite>();
            this.RecipeAlergens = new List<IRecipeAlergen>();
            this.RecipeIngradients = new List<IRecipeIngradient>();
            
        }

         public string Id { get; set; }
         public string CategoryId { get; set; }
         public string UserId { get; set; }
         public string RecipeTitle { get; set; }
         public string RecipeDescription { get; set; }
         public bool RecipeComplexity { get; set; }
         public string RecipeText { get; set; }
         public string Abrv { get; set; }

         public virtual ICategory Category { get; set; }
         public virtual IUser User { get; set; }

         public virtual ICollection<IComment> Comments { get; set; }
         public virtual ICollection<IFavourite> Favourites { get; set; }
        
         public virtual ICollection<IRecipeAlergen> RecipeAlergens { get; set; }
         public virtual ICollection<IRecipeIngradient> RecipeIngradients { get; set; }
        

    }
}
