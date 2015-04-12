using System;
using System.Collections.Generic;

namespace OnlineCookbook.DAL.Models
{
    public partial class RecipeIngradient
    {
        public int Id { get; set; }
        public int IngradientQuantity { get; set; }
        public string IngradientUnit { get; set; }
        public int RecipeId { get; set; }
        public int IngradientId { get; set; }
        public virtual Ingradient Ingradient { get; set; }
        public virtual Recipe Recipe { get; set; }
    }
}
