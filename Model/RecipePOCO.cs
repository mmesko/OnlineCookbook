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
            this.PreparationSteps = new List<IPreparationStep>();
            this.RecipeAlergens = new List<IRecipeAlergen>();
            this.RecipeIngradients = new List<IRecipeIngradient>();
            this.RecipePictures = new List<IRecipePicture>();
        }

         public System.Guid Id { get; set; }
         public System.Guid CategoryId { get; set; }
         public System.Guid UserId { get; set; }
         public string RecipeTitle { get; set; }
         public string RecipeDescription { get; set; }
         public bool RecipeComplexity { get; set; }
         public string RecipeText { get; set; }
         public System.Guid Abrv { get; set; }
         public bool HasPicture { get; set; }
         public virtual ICategory Category { get; set; }
         public virtual ICollection<IComment> Comments { get; set; }
         public virtual ICollection<IFavourite> Favourites { get; set; }
         public virtual ICollection<IPreparationStep> PreparationSteps { get; set; }
         public virtual IUser User { get; set; }
         public virtual ICollection<IRecipeAlergen> RecipeAlergens { get; set; }
         public virtual ICollection<IRecipeIngradient> RecipeIngradients { get; set; }
         public virtual ICollection<IRecipePicture> RecipePictures { get; set; }

    }
}
