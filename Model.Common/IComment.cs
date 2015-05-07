using System;

namespace OnlineCookbook.Model.Common
{
   public interface IComment
    {
        Guid Id { get; set; }
        Guid Userid { get; set; }
        Guid RecipeId { get; set; }
        string CommentText { get; set; }
        IRecipe Recipe { get; set; }
        IUser User { get; set; }
    }
}
