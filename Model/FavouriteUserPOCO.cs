using System;
using System.Collections.Generic;
using OnlineCookbook.Model.Common;

namespace OnlineCookbook.Model
{
    public partial class FavouriteUserPOCO : IFavouriteUser
    {
        public System.Guid Id { get; set; }
        public System.Guid UserId { get; set; }
        public System.Guid FavouriteId { get; set; }
        public virtual FavouritePOCO Favourite { get; set; }
        public virtual UserPOCO User { get; set; }
    }
}
