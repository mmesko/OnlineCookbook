using System;
using System.Collections.Generic;
using OnlineCookbook.Model.Common;

namespace OnlineCookbook.Model
{
    public partial class CategoryPOCO : ICategory
    {
        public CategoryPOCO()
        {
            this.Recipes = new List<IRecipe>();
        }

        public string Id { get; set; }
        public string CategoryName { get; set; }
        public string Abrv { get; set; }
        public virtual ICollection<IRecipe> Recipes { get; set; }

    }
}
