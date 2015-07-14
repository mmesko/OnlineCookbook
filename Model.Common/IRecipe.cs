using System;
using System.Collections.Generic;

namespace OnlineCookbook.Model.Common
{
    public interface IRecipe
    {
        string Id { get; set; }
        string CategoryId { get; set; }
        string UserId { get; set; }
        string RecipeTitle { get; set; }
        string RecipeDescription { get; set; }
        bool RecipeComplexity { get; set; }
        string RecipeText { get; set; }
        string Abrv { get; set; }
       

        ICategory Category { get; set; }
        ICollection<IComment> Comments { get; set; }
        ICollection<IFavourite> Favourites { get; set; }
        
        IUser User { get; set; }
        ICollection<IRecipeAlergen> RecipeAlergens { get; set; }
        ICollection<IRecipeIngradient> RecipeIngradients { get; set; }
       
             
    }
}
