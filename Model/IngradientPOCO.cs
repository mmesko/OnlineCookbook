using System;
using System.Collections.Generic;
using OnlineCookbook.Model.Common;

namespace OnlineCookbook.Model
{
    public partial class IngradientPOCO : IIngradient
    {
         public IngradientPOCO()
        {
            this.RecipeIngradients = new List<IRecipeIngradient>();
        }

         public string Id { get; set; }
         public string IngradientName { get; set; }
         public string Abrv { get; set; }
         public virtual ICollection<IRecipeIngradient> RecipeIngradients { get; set; }
    }
}
