using System;
using System.Collections.Generic;
using OnlineCookbook.Model.Common;

namespace OnlineCookbook.Model
{
    public partial class FavouritePOCO : IFavourite
    {

        public FavouritePOCO()
        {
            this.FavouriteUsers = new List<FavouriteUserPOCO>();
        }

        public System.Guid Id { get; set; }
        public System.Guid RecipeId { get; set; }
        public string FavouriteName { get; set; }
        public System.Guid Abrv { get; set; }
        public virtual RecipePOCO Recipe { get; set; }
        public virtual ICollection<FavouriteUserPOCO> FavouriteUsers { get; set; }

    }
}
