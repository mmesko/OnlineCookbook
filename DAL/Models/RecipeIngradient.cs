using System;
using System.Collections.Generic;

namespace OnlineCookbook.DAL.Models
{
    public partial class RecipeIngradient
    {
        public string Id { get; set; }
        public string IngradientId { get; set; }
        public string RecipeId { get; set; }
        public int IngradientQuantity { get; set; }
        public string IngradientUnit { get; set; }
        public virtual Ingradient Ingradient { get; set; }
        public virtual Recipe Recipe { get; set; }
    }
}
