using System;
using System.Collections.Generic;

namespace OnlineCookbook.DAL.Models
{
    public partial class Alergen
    {
        public Alergen()
        {
            this.RecipeAlergens = new List<RecipeAlergen>();
        }

        public int Id { get; set; }
        public string AlergenName { get; set; }
        public virtual ICollection<RecipeAlergen> RecipeAlergens { get; set; }
    }
}
