using System;
using System.Collections.Generic;

namespace OnlineCookbook.DAL.Models
{
    public partial class Comment
    {
        public System.Guid Id { get; set; }
        public System.Guid Userid { get; set; }
        public System.Guid RecipeId { get; set; }
        public string CommentText { get; set; }
        public virtual Recipe Recipe { get; set; }
        public virtual User User { get; set; }
    }
}
