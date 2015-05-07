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

        public System.Guid Id { get; set; }
        public string AlergenName { get; set; }
        public System.Guid Abrv { get; set; }
        public virtual ICollection<RecipeAlergenPOCO> RecipeAlergens { get; set; }
    }
}

