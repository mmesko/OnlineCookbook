using System.Collections.Generic;
using System.Threading.Tasks;
using OnlineCookbook.Model.Common;
using OnlineCookbook.Common.Filters;

namespace OnlineCookbook.Service.Common
{
    public interface IFavouriteService
    {
        Task<List<IFavourite>> GetAsync(FavouriteFilter filter);
        Task<IFavourite> GetAsync(string id);
        Task<List<IFavourite>> GetNameAsync(string name);
        Task<int> InsertAsync(IFavourite entity);
        Task<int> UpdateAsync(IFavourite entity);
        Task<int> DeleteAsync(IFavourite entity);
        Task<int> DeleteAsync(string id);
    }
}
