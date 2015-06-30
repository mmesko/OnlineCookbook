using System;
using System.Collections.Generic;

namespace OnlineCookbook.DAL.Models
{
    public partial class RecipeAlergen
    {
        public string Id { get; set; }
        public string AlergenId { get; set; }
        public string RecipeId { get; set; }
        public int AlergenQuantity { get; set; }
        public string AlergenUnit { get; set; }
        public virtual Alergen Alergen { get; set; }
        public virtual Recipe Recipe { get; set; }
    }
}
