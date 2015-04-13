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
        public virtual FavouritePOCO Favourite { get; set; }
        public virtual UserPOCO User { get; set; }
    }
}
