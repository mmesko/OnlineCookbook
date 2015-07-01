using System;
using System.Collections.Generic;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineCookbook.DAL.Models
{
   
    public partial class User : IdentityUser

    {
        public User()
        {
           
            this.Comments = new List<Comment>();
            this.FavouriteUsers = new List<FavouriteUser>();
            this.MessageUsers = new List<MessageUser>();
            this.Recipes = new List<Recipe>();
           // this.UserClaims = new List<UserClaim>();
          //  this.UserLogins = new List<UserLogin>();
          //  this.UserRoles = new List<UserRole>();
        }

        public override string Id
        {
            get
            {
                return base.Id;
            }
            set
            {
                if (String.IsNullOrEmpty(value))
                    base.Id = Guid.NewGuid().ToString();
                else
                    base.Id = value;
            }
        }

            
        public override string UserName { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }

      
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<FavouriteUser> FavouriteUsers { get; set; }
        public virtual ICollection<MessageUser> MessageUsers { get; set; }
        public virtual ICollection<Recipe> Recipes { get; set; }
       // public virtual ICollection<UserClaim> UserClaims { get; set; }
       // public virtual ICollection<UserLogin> UserLogins { get; set; }
       // public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}
