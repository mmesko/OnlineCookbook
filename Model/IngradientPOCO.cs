using System;
using System.Collections.Generic;
using OnlineCookbook.Model.Common;

namespace OnlineCookbook.Model
{
    public partial class IngradientPOCO : IIngradient
    {
         public IngradientPOCO()
        {
            this.RecipeIngradients = new List<RecipeIngradientPOCO>();
        }

        public int Id { get; set; }
        public string IngradientName { get; set; }
        public virtual ICollection<RecipeIngradientPOCO> RecipeIngradients { get; set; }
    }
}
