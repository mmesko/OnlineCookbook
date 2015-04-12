using System;
using System.Collections.Generic;

namespace OnlineCookbook.DAL.Models
{
    public partial class RecipeAlergen
    {
        public int Id { get; set; }
        public int AlergenQuantity { get; set; }
        public string AlergenUntit { get; set; }
        public int RecipeId { get; set; }
        public int AlergenId { get; set; }
        public virtual Alergen Alergen { get; set; }
        public virtual Recipe Recipe { get; set; }
    }
}
