using System;
using System.Collections.Generic;
using OnlineCookbook.Model.Common;

namespace OnlineCookbook.Model
{
    public partial class FavouriteUserPOCO : IFavouriteUser
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public string FavouriteId { get; set; }
        public virtual IFavourite Favourite { get; set; }
        public virtual IUser User { get; set; }
    }
}
