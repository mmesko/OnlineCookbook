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

        public System.Guid Id { get; set; }
        public System.Guid RecipeId { get; set; }
        public string FavouriteName { get; set; }
        public System.Guid Abrv { get; set; }
        public virtual IRecipe Recipe { get; set; }
        public virtual ICollection<IFavouriteUser> FavouriteUsers { get; set; }

    }
}
