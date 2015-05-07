using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OnlineCookbook.Model.Common;

using System.Threading.Tasks;

namespace OnlineCookbook.Service.Common
{
   public interface IAlergenService
    {
        Task<List<IAlergen>> GetAsync(string sortOrder = "alergenId", int pageNumber = 0, int pageSize = 20);
        Task<IAlergen> GetAsync(Guid id);
        Task<int> InsertAsync(IAlergen entity);
        Task<int> UpdateAsync(IAlergen entity);
        Task<int> DeleteAsync(IAlergen entity);
        Task<int> DeleteAsync(Guid id);

    }
}
