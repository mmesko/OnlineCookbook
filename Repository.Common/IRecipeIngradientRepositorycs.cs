using System;
using System.Linq;
using System.Collections.Generic;
using OnlineCookbook.Model.Common;
using System.Threading.Tasks;

namespace OnlineCookbook.Repository.Common
{
   public interface IRecipeIngradientRepositorycs
    {
        Task<List<IRecipeIngradient>> GetAsync(string sortOrder = "recipeIngradientId", int pageNumber = 0, int pageSize = 20);
        Task<IRecipeIngradient> GetAsync(Guid id);
        Task<int> InsertAsync(IRecipeIngradient entity);
        Task<int> UpdateAsync(IRecipeIngradient entity);
        Task<int> DeleteAsync(IRecipeIngradient entity);
        Task<int> DeleteAsync(Guid id);
    }
}
