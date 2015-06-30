using System;
using System.Collections.Generic;
using OnlineCookbook.Model.Common;

namespace OnlineCookbook.Model
{
    public partial class CommentPOCO : IComment
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public string RecipeId { get; set; }
        public string CommentText { get; set; }
        public virtual IRecipe Recipe { get; set; }
        public virtual IUser User { get; set; }

    }
}
