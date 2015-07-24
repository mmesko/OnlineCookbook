using System;
using System.Collections.Generic;

namespace OnlineCookbook.DAL.Models
{
    public partial class Comment
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public string RecipeId { get; set; }
        public string CommentText { get; set; }
        public Nullable<System.DateTime> DateCreated { get; set; }
        public virtual Recipe Recipe { get; set; }
        public virtual User User { get; set; }
    }
}
