using System;
using System.Collections.Generic;
using OnlineCookbook.Model.Common;

namespace OnlineCookbook.Model
{
    public partial class CategoryPOCO : ICategory
    {
        public CategoryPOCO()
        {
            //this.Recipes = new List<Recipe>();
        }

        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string abrv { get; set; }
       // public virtual ICollection<Recipe> Recipes { get; set; }

    }
}
