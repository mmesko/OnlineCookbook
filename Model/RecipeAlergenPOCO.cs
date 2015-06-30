using System;
using System.Collections.Generic;
using OnlineCookbook.Model.Common;

namespace OnlineCookbook.Model
{
    public partial class RecipeAlergenPOCO : IRecipeAlergen
    {
        public string Id { get; set; }
        public string AlergenId { get; set; }
        public string RecipeId { get; set; }
        public int AlergenQuantity { get; set; }
        public string AlergenUnit { get; set; }
        public virtual IAlergen Alergen { get; set; }
        public virtual IRecipe Recipe { get; set; }

    }
}
