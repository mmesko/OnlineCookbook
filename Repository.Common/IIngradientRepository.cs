using System;
using System.Linq;
using System.Collections.Generic;
using OnlineCookbook.Model.Common;
using System.Threading.Tasks;
using OnlineCookbook.Filters.ModelFilter;

namespace OnlineCookbook.Repository.Common
{
    public interface IIngradientRepository
    {
        Task<List<IIngradient>> GetAsync(IngradientFilter filter);
        Task<IIngradient> GetAsync(Guid id);
        Task<int> InsertAsync(IIngradient entity);
        Task<int> UpdateAsync(IIngradient entity);
        Task<int> DeleteAsync(IIngradient entity);
        Task<int> DeleteAsync(Guid id);
    }
}
