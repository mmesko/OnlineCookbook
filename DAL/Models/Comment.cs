using System;
using System.Collections.Generic;

namespace OnlineCookbook.DAL.Models
{
    public partial class Comment
    {
        public int Id { get; set; }
        public string CommentText { get; set; }
        public int UserId { get; set; }
        public int RecipeId { get; set; }
        public virtual Recipe Recipe { get; set; }
        public virtual User User { get; set; }
    }
}
