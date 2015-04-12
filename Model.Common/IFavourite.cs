using System;


namespace OnlineCookbook.Model.Common
{
   public interface IFavourite
    {
         int Id { get; set; }
         string FavouriteName { get; set; }
         int RecipeId { get; set; }
       // public virtual Recipe Recipe { get; set; }

    }
}
