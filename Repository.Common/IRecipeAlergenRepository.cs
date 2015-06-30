﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using OnlineCookbook.Model.Common;
using OnlineCookbook.Common.Filters;

namespace OnlineCookbook.Repository.Common
{
   public interface IRecipeAlergenRepository
    {
        Task<List<IRecipeAlergen>> GetAsync(RecipeAlergenFilter filter);
        Task<IRecipeAlergen> GetAsync(string id);
        Task<int> InsertAsync(IRecipeAlergen entity);
        Task<int> UpdateAsync(IRecipeAlergen entity);
        Task<int> DeleteAsync(IRecipeAlergen entity);
        Task<int> DeleteAsync(string id);

       //added 2 tasks
        Task<List<IRecipeAlergen>> GetRecipeAlergenAsync(string recipeId, RecipeAlergenFilter filter);
        //Task<IAlergen> GetAlergenAsync(string alergenId); ili IRecipe??

    }
}
