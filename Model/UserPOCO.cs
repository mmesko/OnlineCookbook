﻿using System;
using System.Collections.Generic;
using OnlineCookbook.Model.Common;

namespace OnlineCookbook.Model
{
    public partial class UserPOCO : IUser
    {
        public UserPOCO()
        {
           /* this.Comments = new List<Comment>();
            this.FavouriteUsers = new List<FavouriteUser>();
            this.MessageUsers = new List<MessageUser>();
            this.Recipes = new List<Recipe>();
            this.UserRoles = new List<UserRole>();*/
        }

        public int Id { get; set; }
        public string FullName { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string SaltKey { get; set; }
        public string RecoweryQuestion { get; set; }
        public string RecoveryAnswer { get; set; }
       /* public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<FavouriteUser> FavouriteUsers { get; set; }
        public virtual ICollection<MessageUser> MessageUsers { get; set; }
        public virtual ICollection<Recipe> Recipes { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; }*/

    }
}
