using System;
using System.Collections.Generic;
using OnlineCookbook.Model.Common;

namespace OnlineCookbook.Model
{
     public partial class AlergenPOCO : IAlergen
    {
        public AlergenPOCO()
        {
            this.RecipeAlergens = new List<RecipeAlergenPOCO>();
        }

        public int Id { get; set; }
        public string AlergenName { get; set; }
        public virtual ICollection<RecipeAlergenPOCO> RecipeAlergens { get; set; }
    }
}

