using System;
using System.Collections.Generic;
using OnlineCookbook.Model.Common;

namespace OnlineCookbook.Model
{
    public partial class CategoryPOCO : ICategory
    {
        public CategoryPOCO()
        {
            this.Recipes = new List<RecipePOCO>();
        }

        public System.Guid Id { get; set; }
        public string CategoryName { get; set; }
        public System.Guid Abrv { get; set; }
        public virtual ICollection<RecipePOCO> Recipes { get; set; }

    }
}
