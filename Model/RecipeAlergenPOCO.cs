using System;
using System.Collections.Generic;
using OnlineCookbook.Model.Common;

namespace OnlineCookbook.Model
{
    public partial class RecipeAlergenPOCO : IRecipeAlergen
    {
        public int Id { get; set; }
        public int AlergenQuantity { get; set; }
        public string AlergenUntit { get; set; }
        public int RecipeId { get; set; }
        public int AlergenId { get; set; }
        public virtual AlergenPOCO Alergen { get; set; }
        public virtual RecipePOCO Recipe { get; set; }

    }
}
