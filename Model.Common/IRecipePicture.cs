using System;

namespace OnlineCookbook.Model.Common
{
    public interface IRecipePicture
    {
        Guid Id { get; set; }
        Guid RecipeId { get; set; }
        byte[] RecipePicture1 { get; set; }
    }
}
