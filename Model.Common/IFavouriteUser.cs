using System;

namespace OnlineCookbook.Model.Common
{
    public interface IFavouriteUser
    {

        Guid Id { get; set; }
        Guid UserId { get; set; }
        Guid FavouriteId { get; set; }
        IFavourite Favourite { get; set; }  
        IUser User { get; set; }
    }
}

