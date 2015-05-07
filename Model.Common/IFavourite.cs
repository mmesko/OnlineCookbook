using System;

namespace OnlineCookbook.Model.Common
{
   public interface IFavourite
    {
       Guid Id { get; set; }
       Guid RecipeId { get; set; }
       string FavouriteName { get; set; }
       Guid Abrv { get; set; }
    }
}
