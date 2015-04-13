using System;
using System.Collections.Generic;
using OnlineCookbook.Model.Common;

namespace OnlineCookbook.Model
{
    public partial class UserPOCO : IUser
    {
        public UserPOCO()
        {
            this.Comments = new List<CommentPOCO>();
            this.FavouriteUsers = new List<FavouriteUserPOCO>();
            this.MessageUsers = new List<MessageUserPOCO>();
            this.Recipes = new List<RecipePOCO>();
            this.UserRoles = new List<UserRolePOCO>();
        }

        public int Id { get; set; }
        public string FullName { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string SaltKey { get; set; }
        public string RecoweryQuestion { get; set; }
        public string RecoveryAnswer { get; set; }
        public virtual ICollection<CommentPOCO> Comments { get; set; }
        public virtual ICollection<FavouriteUserPOCO> FavouriteUsers { get; set; }
        public virtual ICollection<MessageUserPOCO> MessageUsers { get; set; }
        public virtual ICollection<RecipePOCO> Recipes { get; set; }
        public virtual ICollection<UserRolePOCO> UserRoles { get; set; }

    }
}
