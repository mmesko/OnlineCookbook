﻿using System;
using System.Linq;
using System.Collections.Generic;
using OnlineCookbook.Model.Common;
using System.Threading.Tasks;
using OnlineCookbook.Common.Filters;

namespace OnlineCookbook.Repository.Common
{
    public interface IRecipeRepository 
    {
        Task<List<IRecipe>> GetAsync(RecipeFilter filter = null);
        Task<List<IRecipe>> GetAsync(string ingradientId, RecipeFilter filter = null);
        Task<IRecipe> GetAsync(string id);
        Task<List<IRecipe>> GetByNameAsync(string name);
        Task<int> InsertAsync(IRecipe entity);
       
        Task<int> UpdateAsync(IRecipe entity);
        Task<int> DeleteAsync(IRecipe entity);
        Task<int> DeleteAsync(string id);

        //Task<int> GetByComplexityAsync(IRecipe entity); 
        Task<List<IRecipe>> GetByCategoryAsync(string  categoryId, RecipeFilter filter = null);
       
        Task<IUnitOfWork> CreateUnitOfWork();
    }
}
