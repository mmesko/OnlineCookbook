using System;
using System.Linq;
using System.Collections.Generic;
using OnlineCookbook.Model.Common;
using System.Threading.Tasks;

namespace OnlineCookbook.Repository.Common
{
   public interface IRecipeAlergenRepository
    {
        Task<List<IRecipeAlergen>> GetAsync(string sortOrder = "recipeAlergenId", int pageNumber = 0, int pageSize = 20);
        Task<IRecipeAlergen> GetAsync(Guid id);
        Task<int> InsertAsync(IRecipeAlergen entity);
        Task<int> UpdateAsync(IRecipeAlergen entity);
        Task<int> DeleteAsync(IRecipeAlergen entity);
        Task<int> DeleteAsync(Guid id);
    }
}
