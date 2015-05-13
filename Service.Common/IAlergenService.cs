using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OnlineCookbook.Model.Common;
using System.Threading.Tasks;
using OnlineCookbook.Filters.ModelFilter;

namespace OnlineCookbook.Service.Common
{
   public interface IAlergenService
    {
        Task<List<IAlergen>> GetAsync(AlergenFilter filter);
        Task<IAlergen> GetAsync(Guid id);
        Task<int> InsertAsync(IAlergen entity);
        Task<int> UpdateAsync(IAlergen entity);
        Task<int> DeleteAsync(IAlergen entity);
        Task<int> DeleteAsync(Guid id);

    }
}
