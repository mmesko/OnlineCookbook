using System;
using System.Collections.Generic;
using OnlineCookbook.Model.Common;

namespace OnlineCookbook.Model
{
    public partial class FavouriteUserPOCO : IFavouriteUser
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int FavouriteId { get; set; }
        //public virtual Favourite Favourite { get; set; }
        //public virtual User User { get; set; }
    }
}
