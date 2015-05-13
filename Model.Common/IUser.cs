using System;
using System.Collections.Generic;

namespace OnlineCookbook.Model.Common
{
    public interface IUser
    {
        Guid Id { get; set; }
        string FullName { get; set; }
        string Username { get; set; }
        string Password { get; set; }
        string SaltKey { get; set; }
        
        ICollection<IComment> Comments { get; set; }
        ICollection<IFavouriteUser> FavouriteUsers { get; set; }
        ICollection<IMessageUser> MessageUsers { get; set; }
        ICollection<IRecipe> Recipes { get; set; }
        ICollection<IUserRole> UserRoles { get; set; }
    }
}
