using System;
using System.Collections.Generic;
using OnlineCookbook.Model.Common;

namespace OnlineCookbook.Model
{
    public partial class FavouritePOCO : IFavourite
    {

        public FavouritePOCO()
        {
            this.FavouriteUsers = new List<IFavouriteUser>();
        }

        public string Id { get; set; }
        public string RecipeId { get; set; }
        public string FavouriteName { get; set; }
        public string Abrv { get; set; }
        public virtual IRecipe Recipe { get; set; }
        public virtual ICollection<IFavouriteUser> FavouriteUsers { get; set; }

    }
}
