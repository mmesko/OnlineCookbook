using System.Collections.Generic;
using OnlineCookbook.Model.Common;
using System.Threading.Tasks;
using OnlineCookbook.Common.Filters;

namespace OnlineCookbook.Service.Common
{
   public interface IAlergenService
    {
        Task<List<IAlergen>> GetAsync(AlergenFilter filter);
        Task<IAlergen> GetAsync(string id);
        Task<List<IAlergen>> GetNameAsync(string name);
        Task<int> InsertAsync(IAlergen entity);
        Task<int> UpdateAsync(IAlergen entity);
        Task<int> DeleteAsync(IAlergen entity);
        Task<int> DeleteAsync(string id);

    }
}
