using System;
using System.Collections.Generic;

namespace OnlineCookbook.DAL.Models
{
    public partial class FavouriteUser
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int FavouriteId { get; set; }
        public virtual Favourite Favourite { get; set; }
        public virtual User User { get; set; }
    }
}
