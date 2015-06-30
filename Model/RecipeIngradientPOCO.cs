using System;
using OnlineCookbook.Model.Common;

namespace OnlineCookbook.Model
{
    public partial class RecipeIngradientPOCO : IRecipeIngradient
    {
        public string Id { get; set; }
        public string IngradientId { get; set; }
        public string RecipeId { get; set; }
        public int IngradientQuantity { get; set; }
        public string IngradientUnit { get; set; }
        public virtual IIngradient Ingradient { get; set; }
        public virtual IRecipe Recipe { get; set; }

    }
}
