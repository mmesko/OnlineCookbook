using System.Collections.Generic;
using System.Threading.Tasks;
using OnlineCookbook.Common.Filters;
using OnlineCookbook.Model.Common;

namespace OnlineCookbook.Service.Common
{
   public interface IRecipeIngradientService
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
