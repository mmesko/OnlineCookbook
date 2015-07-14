using System;
using System.Linq;
using System.Collections.Generic;
using OnlineCookbook.Model.Common;
using System.Threading.Tasks;
using OnlineCookbook.Common.Filters;

namespace OnlineCookbook.Repository.Common
{
    public interface IAlergenRepository
    {
       // IQueryable<IAlergen> GetAllAsync();
        Task<List<IAlergen>> GetAsync(AlergenFilter filter = null);
        Task<IAlergen> GetAsync(string id);
        Task<List<IAlergen>> GetNameAsync(string name);
        Task<int> InsertAsync(IAlergen entity);
        Task<int> UpdateAsync(IAlergen entity);
        Task<int> DeleteAsync(IAlergen entity);
        Task<int> DeleteAsync(string id);

        
    }
}
