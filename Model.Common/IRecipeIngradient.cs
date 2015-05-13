using System;

namespace OnlineCookbook.Model.Common
{
    public interface IRecipeIngradient
    {
        Guid Id { get; set; }
        Guid IngradientId { get; set; }
        Guid RecipeId { get; set; }
        int IngradientQuantity { get; set; }
        string IngradientUnit { get; set; }
        IIngradient Ingradient { get; set; }
        IRecipe Recipe { get; set; }
    }
}
