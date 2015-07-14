using System;
using System.Collections.Generic;
using OnlineCookbook.Model.Common;
using Microsoft.AspNet.Identity.EntityFramework;
using OnlineCookbook.DAL.Models;
using System.Security.Claims;
using System.Threading.Tasks;

namespace OnlineCookbook.Model
{
    
    public partial class UserPOCO : IdentityUser, IUser
    {
        //public UserPOCO()
        //{
        //    this.Comments = new List<IComment>();
        //    this.FavouriteUsers = new List<IFavouriteUser>();
        //    this.MessageUsers = new List<IMessageUser>();
        //    this.Recipes = new List<IRecipe>();
        //}

        public override string Id
        {
            get
            {
                return base.Id;
            }
            set
            {
                if (String.IsNullOrEmpty(Id))
                    base.Id = Guid.NewGuid().ToString();
                else
                    base.Id = value;
            }
        }

        

        public virtual ICollection<IComment> Comments { get; set; }
        public virtual ICollection<IFavouriteUser> FavouriteUsers { get; set; }
        public virtual ICollection<IMessageUser> MessageUsers { get; set; }
        public virtual ICollection<IRecipe> Recipes { get; set; }


       
    }
}
