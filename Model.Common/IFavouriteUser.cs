using System;

namespace OnlineCookbook.Model.Common
{
    public interface IFavouriteUser
    {

        Guid Id { get; set; }
        Guid UserId { get; set; }
        Guid FavouriteId { get; set; }
        //public virtual Favourite Favourite { get; set; }  ovo ne?
        //public virtual User User { get; set; }
    }
}

