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

        public System.Guid Id { get; set; }
        public string CategoryName { get; set; }
        public System.Guid Abrv { get; set; }
        public virtual ICollection<Recipe> Recipes { get; set; }
    }
}
