using System.Collections.Generic;
using OnlineCookbook.Model.Common;
using System.Threading.Tasks;
using OnlineCookbook.Common.Filters;

namespace OnlineCookbook.Repository.Common
{
    public interface IFavouriteRepository
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
