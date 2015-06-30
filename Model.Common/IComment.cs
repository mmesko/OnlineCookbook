using System;

namespace OnlineCookbook.Model.Common
{
   public interface IComment
    {
        string Id { get; set; }
        string UserId { get; set; }
        string RecipeId { get; set; }
        string CommentText { get; set; }
        IRecipe Recipe { get; set; }
        IUser User { get; set; }
    }
}
