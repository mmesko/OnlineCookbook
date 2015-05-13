using System;

namespace OnlineCookbook.Model.Common
{
   public interface IRecipeAlergen
    {
        Guid Id { get; set; }
        Guid AlergenId { get; set; }
        Guid RecipeId { get; set; }
        int AlergenQuantity { get; set; }
        string AlergenUnit { get; set; }
        IAlergen Alergen { get; set; }
        IRecipe Recipe { get; set; }
    }
}
