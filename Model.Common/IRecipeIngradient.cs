using System;

namespace OnlineCookbook.Model.Common
{
    public interface IRecipeIngradient
    {
        string Id { get; set; }
        string IngradientId { get; set; }
        string RecipeId { get; set; }
        int IngradientQuantity { get; set; }
        string IngradientUnit { get; set; }
        IIngradient Ingradient { get; set; }
        IRecipe Recipe { get; set; }
    }
}
