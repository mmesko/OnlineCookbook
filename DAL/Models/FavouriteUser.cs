using System;
using System.Collections.Generic;

namespace OnlineCookbook.DAL.Models
{
    public partial class FavouriteUser
    {
        public System.Guid Id { get; set; }
        public System.Guid UserId { get; set; }
        public System.Guid FavouriteId { get; set; }
        public virtual Favourite Favourite { get; set; }
        public virtual User User { get; set; }
    }
}
