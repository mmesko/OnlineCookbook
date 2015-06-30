using System;

namespace OnlineCookbook.Model.Common
{
    public interface IFavouriteUser
    {

        string Id { get; set; }
        string UserId { get; set; }
        string FavouriteId { get; set; }
        IFavourite Favourite { get; set; }  
        IUser User { get; set; }
    }
}

