using System;
using System.Collections.Generic;

namespace OnlineCookbook.DAL.Models
{
    public partial class Category
    {
        public Category()
        {
            this.Recipes = new List<Recipe>();
        }

        public string Id { get; set; }
        public string CategoryName { get; set; }
        public string Abrv { get; set; }
        public virtual ICollection<Recipe> Recipes { get; set; }
    }
}
