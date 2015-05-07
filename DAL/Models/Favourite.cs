using System;
using System.Collections.Generic;

namespace OnlineCookbook.DAL.Models
{
    public partial class Favourite
    {
        public Favourite()
        {
            this.FavouriteUsers = new List<FavouriteUser>();
        }

        public System.Guid Id { get; set; }
        public System.Guid RecipeId { get; set; }
        public string FavouriteName { get; set; }
        public System.Guid Abrv { get; set; }
        public virtual Recipe Recipe { get; set; }
        public virtual ICollection<FavouriteUser> FavouriteUsers { get; set; }
    }
}
