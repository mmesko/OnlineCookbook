using System;
using System.Linq;
using System.Collections.Generic;
using OnlineCookbook.Model.Common;
using System.Threading.Tasks;
using OnlineCookbook.Common.Filters;

namespace OnlineCookbook.Repository.Common
{
    public interface IIngradientRepository
    {
        Task<List<IIngradient>> GetAsync(IngradientFilter filter = null);
        Task<IIngradient> GetAsync(string id);
        Task<List<IIngradient>> GetNameAsync(string name);
        Task<int> InsertAsync(IIngradient entity);
        Task<int> UpdateAsync(IIngradient entity);
        Task<int> DeleteAsync(IIngradient entity);
        Task<int> DeleteAsync(string id);
    }
}
