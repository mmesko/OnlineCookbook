using System;
using System.Collections.Generic;
using OnlineCookbook.Model.Common;

namespace OnlineCookbook.Model
{
    public partial class RecipeIngradientPOCO : IRecipeIngradient
    {
        public System.Guid Id { get; set; }
        public System.Guid IngradientId { get; set; }
        public System.Guid RecipeId { get; set; }
        public int IngradientQuantity { get; set; }
        public string IngradientUnit { get; set; }
        public virtual IngradientPOCO Ingradient { get; set; }
        public virtual RecipePOCO Recipe { get; set; }

    }
}
