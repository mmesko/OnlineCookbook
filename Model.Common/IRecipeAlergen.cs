using System;

namespace OnlineCookbook.Model.Common
{
   public interface IRecipeAlergen
    {
        string Id { get; set; }
        string AlergenId { get; set; }
        string RecipeId { get; set; }
        int AlergenQuantity { get; set; }
        string AlergenUnit { get; set; }
        IAlergen Alergen { get; set; }
        IRecipe Recipe { get; set; }
    }
}
