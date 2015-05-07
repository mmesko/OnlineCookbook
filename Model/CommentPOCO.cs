using System;
using System.Collections.Generic;
using OnlineCookbook.Model.Common;

namespace OnlineCookbook.Model
{
    public partial class CommentPOCO : IComment
    {
        public System.Guid Id { get; set; }
        public System.Guid Userid { get; set; }
        public System.Guid RecipeId { get; set; }
        public string CommentText { get; set; }
        public virtual RecipePOCO Recipe { get; set; }
        public virtual UserPOCO User { get; set; }

    }
}
