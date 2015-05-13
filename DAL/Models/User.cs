using System;
using System.Collections.Generic;

namespace OnlineCookbook.DAL.Models
{
    public partial class User
    {
        public User()
        {
            this.Comments = new List<Comment>();
            this.FavouriteUsers = new List<FavouriteUser>();
            this.MessageUsers = new List<MessageUser>();
            this.Recipes = new List<Recipe>();
            this.UserRoles = new List<UserRole>();
        }

        public System.Guid Id { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string SaltKey { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<FavouriteUser> FavouriteUsers { get; set; }
        public virtual ICollection<MessageUser> MessageUsers { get; set; }
        public virtual ICollection<Recipe> Recipes { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}
