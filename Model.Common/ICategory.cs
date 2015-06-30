using System;
using System.Collections.Generic;

namespace OnlineCookbook.Model.Common
{
   public interface ICategory
    {
        string Id { get; set; }
        string CategoryName { get; set; }
        string Abrv { get; set; }
       ICollection<IRecipe> Recipes { get; set; }
    }
}
