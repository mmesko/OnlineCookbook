using System;
using System.Collections.Generic;
using OnlineCookbook.Model.Common;

namespace OnlineCookbook.Model
{
    public partial class IngradientPOCO : IIngradient
    {
         public IngradientPOCO()
        {
            //this.RecipeIngradients = new List<RecipeIngradient>();
        }

        public int Id { get; set; }
        public string IngradientName { get; set; }
        //public virtual ICollection<RecipeIngradient> RecipeIngradients { get; set; }
    }
}
