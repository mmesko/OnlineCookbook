using System;
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
        Task<IRecipe> GetAsync(string id);
        Task<List<IRecipe>> GetByNameAsync(string name);
        Task<int> InsertAsync(IRecipe entity);
        Task<int> AddAsync(IUnitOfWork unitOfWork, IRecipe entity);
        Task<int> UpdateAsync(IRecipe entity);
        Task<int> DeleteAsync(IUnitOfWork unitOfWork, IRecipe entity);
        Task<int> DeleteAsync(IUnitOfWork unitOfWork, string id);

        //Task<int> GetByComplexityAsync(IRecipe entity);
        Task<List<IRecipe>> GetByCategoryAsync(string  categoryId, RecipeFilter filter = null);
        // Task<List<IRecipe>> GetByIngradientAsync(string ingradientId); staviti u service -> business logic
        Task<IUnitOfWork> CreateUnitOfWork();
    }
}
