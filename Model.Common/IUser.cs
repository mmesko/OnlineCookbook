using System;
using System.Collections.Generic;


namespace OnlineCookbook.Model.Common
{
    public interface IUser
    {
        string Id { get; set; }
        string UserName { get; set; }
        string PasswordHash { get; set; }
        string Email { get; set; }


        
       ICollection<IComment> Comments { get; set; }
       ICollection<IFavouriteUser> FavouriteUsers { get; set; }
       ICollection<IMessageUser> MessageUsers { get; set; }
       ICollection<IRecipe> Recipes { get; set; }
    }
}
