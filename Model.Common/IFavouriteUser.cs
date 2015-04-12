using System;


namespace OnlineCookbook.Model.Common
{
    public interface IFavouriteUser
    {

        int Id { get; set; }
        int UserId { get; set; }
        int FavouriteId { get; set; }
        //public virtual Favourite Favourite { get; set; }
        //public virtual User User { get; set; }
    }
}

