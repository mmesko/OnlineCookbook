using System;
using System.Collections.Generic;
using Microsoft.AspNet.Identity.EntityFramework;

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
          
        }

        //override because you use identity id!
        override public string Id { get; set; }
       
      
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<FavouriteUser> FavouriteUsers { get; set; }
        public virtual ICollection<MessageUser> MessageUsers { get; set; }
        public virtual ICollection<Recipe> Recipes { get; set; }

        //no foreign key in user
       
    }
}
