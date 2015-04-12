using System;


namespace OnlineCookbook.Model.Common
{
   public interface IComment
    {

         int Id { get; set; }
         string CommentText { get; set; }
         int UserId { get; set; }
         int RecipeId { get; set; }
       // public virtual Recipe Recipe { get; set; }
       // public virtual User User { get; set; }

    }
}
