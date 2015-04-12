using System;
using System.Collections.Generic;
using OnlineCookbook.Model.Common;

namespace OnlineCookbook.Model
{
    public partial class CommentPOCO : IComment
    {
        public int Id { get; set; }
        public string CommentText { get; set; }
        public int UserId { get; set; }
        public int RecipeId { get; set; }
        //public virtual Recipe Recipe { get; set; }
       // public virtual User User { get; set; }

    }
}
