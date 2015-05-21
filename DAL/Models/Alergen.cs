using System;
using System.Collections.Generic;

namespace OnlineCookbook.DAL.Models
{
    public partial class Alergen
    {
        private Guid guid;

        public Alergen()
        {
            this.RecipeAlergens = new List<RecipeAlergen>();
        }

       

        public System.Guid Id { get; set; }
        public string AlergenName { get; set; }
        public System.Guid Abrv { get; set; }
        public virtual ICollection<RecipeAlergen> RecipeAlergens { get; set; }
    }
}
