using System;
using System.Linq;
using System.Collections.Generic;
using OnlineCookbook.Model.Common;
using System.Threading.Tasks;
using OnlineCookbook.Filters.ModelFilter;

namespace OnlineCookbook.Repository.Common
{
    public interface IAlergenRepository 
    {
        Task<List<IAlergen>> GetAsync(AlergenFilter filter);
        Task<IAlergen> GetAsync(Guid id);
        Task<int> InsertAsync(IAlergen entity);
        Task<int> UpdateAsync(IAlergen entity);
        Task<int> DeleteAsync(IAlergen entity);
        Task<int> DeleteAsync(Guid id);

        
    }
}
