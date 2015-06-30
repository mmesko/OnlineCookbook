using System;
using System.Collections.Generic;

namespace OnlineCookbook.Model.Common
{
   public interface IFavourite
    {
       string Id { get; set; }
       string RecipeId { get; set; }
       string FavouriteName { get; set; }
       string Abrv { get; set; }
       IRecipe Recipe { get; set; }
       ICollection<IFavouriteUser> FavouriteUsers { get; set; }
    }
}
