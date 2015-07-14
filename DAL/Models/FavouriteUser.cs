using System;
using System.Collections.Generic;

namespace OnlineCookbook.DAL.Models
{
    public partial class FavouriteUser
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public string FavouriteId { get; set; }
        public virtual Favourite Favourite { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
