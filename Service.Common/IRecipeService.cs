using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OnlineCookbook.Model.Common;
using System.Threading.Tasks;
using OnlineCookbook.Common.Filters;

namespace OnlineCookbook.Service.Common
{
    public interface IRecipeService
    {
        Task<List<IRecipe>> GetAsync(RecipeFilter filter = null);
        Task<IRecipe> GetAsync(string id);
        Task<List<IRecipe>> GetByNameAsync(string name);
        //Task<List<IRecipe>> GetByCategoryAsync(string categoryId, RecipeFilter filter = null);

        Task<int> InsertAsync(IRecipe entity);

        Task<int> UpdateAsync(IRecipe entity);

        Task<int> DeleteAsync(IRecipe entity);
        Task<int> DeleteAsync(string id);

    }
}
