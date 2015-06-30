using System.Collections.Generic;
using OnlineCookbook.Model.Common;
using System.Threading.Tasks;
using OnlineCookbook.Common.Filters;

namespace OnlineCookbook.Repository.Common
{
   public interface IRecipeIngradientRepository
    {
        Task<List<IRecipeIngradient>> GetAsync(RecipeIngradientFilter filter = null);
        Task<IRecipeIngradient> GetAsync(string id);
        Task<int> InsertAsync(IRecipeIngradient entity);
        Task<int> UpdateAsync(IRecipeIngradient entity);
        Task<int> DeleteAsync(IRecipeIngradient entity);
        Task<int> DeleteAsync(string id);
        Task<List<IRecipeIngradient>> GetRecipeIngradientAsync(string recipeId, RecipeIngradientFilter filter = null);
    }
}
