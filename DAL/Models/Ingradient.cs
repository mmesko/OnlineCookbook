using System;
using System.Collections.Generic;

namespace OnlineCookbook.DAL.Models
{
    public partial class Ingradient
    {
        public Ingradient()
        {
            this.RecipeIngradients = new List<RecipeIngradient>();
        }

        public int Id { get; set; }
        public string IngradientName { get; set; }
        public virtual ICollection<RecipeIngradient> RecipeIngradients { get; set; }
    }
}
