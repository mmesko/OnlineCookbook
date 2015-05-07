using System;
using System.Collections.Generic;

namespace OnlineCookbook.DAL.Models
{
    public partial class RecipeAlergen
    {
        public System.Guid Id { get; set; }
        public System.Guid AlergenId { get; set; }
        public System.Guid RecipeId { get; set; }
        public int AlergenQuantity { get; set; }
        public string AlergenUnit { get; set; }
        public virtual Alergen Alergen { get; set; }
        public virtual Recipe Recipe { get; set; }
    }
}
