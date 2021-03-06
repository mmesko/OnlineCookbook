﻿using System.Collections.Generic;
using OnlineCookbook.Model.Common;
using System.Threading.Tasks;
using OnlineCookbook.Common.Filters;

namespace OnlineCookbook.Service.Common
{
   public interface IRecipeAlergenService
    {
        Task<List<IRecipeAlergen>> GetAsync(RecipeAlergenFilter filter = null);
        Task<IRecipeAlergen> GetAsync(string id);
        Task<int> InsertAsync(IRecipeAlergen entity);
        Task<int> UpdateAsync(IRecipeAlergen entity);
        Task<int> DeleteAsync(IRecipeAlergen entity);
        Task<int> DeleteAsync(string id);

        Task<List<IRecipe>> GetRecipeAlergenAsync(string recipeId, string alergenUnit);

    }
}
