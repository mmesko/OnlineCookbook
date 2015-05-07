using System;
using System.Linq;
using System.Collections.Generic;
using OnlineCookbook.Model.Common;
using System.Threading.Tasks;

namespace OnlineCookbook.Repository.Common
{
    public interface IRecipeRepository 
    {
        Task<List<IRecipe>> GetAsync(string sortOrder = "recipeId", int pageNumber = 0, int pageSize = 20);
        Task<IRecipe> GetAsync(Guid id);
        Task<int> InsertAsync(IRecipe entity);
        Task<int> UpdateAsync(IRecipe entity);
        Task<int> DeleteAsync(IRecipe entity);
        Task<int> DeleteAsync(Guid id);
        Task<List<IRecipe>> GetByAlergenAsync(Guid alergenId);
        Task<List<IRecipe>> GetByIngradientAsync(Guid ingradientId);
    }
}
