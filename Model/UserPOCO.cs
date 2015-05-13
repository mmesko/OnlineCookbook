using System;
using System.Collections.Generic;
using OnlineCookbook.Model.Common;

namespace OnlineCookbook.Model
{
    public partial class UserPOCO : IUser
    {
        public UserPOCO()
        {
            this.Comments = new List<IComment>();
            this.FavouriteUsers = new List<IFavouriteUser>();
            this.MessageUsers = new List<IMessageUser>();
            this.Recipes = new List<IRecipe>();
            this.UserRoles = new List<IUserRole>();
        }

        public System.Guid Id { get; set; }
        public string FullName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string SaltKey { get; set; }
        public virtual ICollection<IComment> Comments { get; set; }
        public virtual ICollection<IFavouriteUser> FavouriteUsers { get; set; }
        public virtual ICollection<IMessageUser> MessageUsers { get; set; }
        public virtual ICollection<IRecipe> Recipes { get; set; }
        public virtual ICollection<IUserRole> UserRoles { get; set; }

    }
}
