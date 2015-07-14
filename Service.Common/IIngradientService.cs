using System.Collections.Generic;
using OnlineCookbook.Model.Common;
using System.Threading.Tasks;
using OnlineCookbook.Common.Filters;

namespace OnlineCookbook.Service.Common
{
   public interface IIngradientService
    {

        Task<List<IIngradient>> GetAsync(IngradientFilter filter);
        Task<IIngradient> GetAsync(string id);
        Task<List<IIngradient>> GetNameAsync(string name);
        Task<int> InsertAsync(IIngradient entity);
        Task<int> UpdateAsync(IIngradient entity);
        Task<int> DeleteAsync(IIngradient entity);
        Task<int> DeleteAsync(string id);

    }
}
