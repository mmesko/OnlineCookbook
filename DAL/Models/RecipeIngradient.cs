using System;
using System.Collections.Generic;

namespace OnlineCookbook.DAL.Models
{
    public partial class RecipeIngradient
    {
        public System.Guid Id { get; set; }
        public System.Guid IngradientId { get; set; }
        public System.Guid RecipeId { get; set; }
        public int IngradientQuantity { get; set; }
        public string IngradientUnit { get; set; }
        public virtual Ingradient Ingradient { get; set; }
        public virtual Recipe Recipe { get; set; }
    }
}
