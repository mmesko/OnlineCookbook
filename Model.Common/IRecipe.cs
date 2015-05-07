using System;
using System.Collections.Generic;

namespace OnlineCookbook.Model.Common
{
    public interface IRecipe
    {
        Guid Id { get; set; }
        Guid CategoryId { get; set; }
        Guid UserId { get; set; }
        string RecipeTitle { get; set; }
        string RecipeDescription { get; set; }
        bool RecipeComplexity { get; set; }
        string RecipeText { get; set; }
        Guid Abrv { get; set; }
        bool HasPicture { get; set; }

        ICategory Category { get; set; }
        ICollection<IComment> Comments { get; set; }
        ICollection<IFavourite> Favourites { get; set; }
        ICollection<IPreparationStep> PreparationSteps { get; set; }
        IUser User { get; set; }
        ICollection<IRecipeAlergen> RecipeAlergens { get; set; }
        ICollection<IRecipeIngradient> RecipeIngradients { get; set; }
        ICollection<IRecipePicture> RecipePictures { get; set; }
             
    }
}
