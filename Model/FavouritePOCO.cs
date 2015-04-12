using System;
using System.Collections.Generic;
using OnlineCookbook.Model.Common;

namespace OnlineCookbook.Model
{
    public partial class FavouritePOCO : IFavourite
    {

        public FavouritePOCO()
        {
           // this.FavouriteUsers = new List<FavouriteUser>();
        }

        public int Id { get; set; }
        public string FavouriteName { get; set; }
        public int RecipeId { get; set; }
        //public virtual Recipe Recipe { get; set; }
        //public virtual ICollection<FavouriteUser> FavouriteUsers { get; set; }

    }
}
