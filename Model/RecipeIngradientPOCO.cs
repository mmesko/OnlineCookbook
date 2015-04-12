using System;
using System.Collections.Generic;
using OnlineCookbook.Model.Common;

namespace OnlineCookbook.Model
{
    public partial class RecipeIngradientPOCO : IRecipeIngradient
    {
        public int Id { get; set; }
        public int IngradientQuantity { get; set; }
        public string IngradientUnit { get; set; }
        public int RecipeId { get; set; }
        public int IngradientId { get; set; }
        //public virtual Ingradient Ingradient { get; set; }
        //public virtual Recipe Recipe { get; set; }

    }
}
