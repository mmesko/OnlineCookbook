using System;
using System.Collections.Generic;
using OnlineCookbook.Model.Common;

namespace OnlineCookbook.Model
{
    public partial class RecipeAlergenPOCO : IRecipeAlergen
    {
        public System.Guid Id { get; set; }
        public System.Guid AlergenId { get; set; }
        public System.Guid RecipeId { get; set; }
        public int AlergenQuantity { get; set; }
        public string AlergenUnit { get; set; }
        public virtual IAlergen Alergen { get; set; }
        public virtual IRecipe Recipe { get; set; }

    }
}
