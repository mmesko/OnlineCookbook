using System;
using System.Collections.Generic;
using OnlineCookbook.Model.Common;

namespace OnlineCookbook.Model
{
     public partial class AlergenPOCO : IAlergen
    {
        public AlergenPOCO()
        {
            this.RecipeAlergens = new List<IRecipeAlergen>();
        }

        public string Id { get; set; }
        public string AlergenName { get; set; }
        public string Abrv { get; set; }
        public virtual ICollection<IRecipeAlergen> RecipeAlergens { get; set; }
    }
}

