using System;
using System.Linq;
using System.Collections.Generic;
using OnlineCookbook.Model.Common;
using System.Threading.Tasks;

namespace OnlineCookbook.Repository.Common
{
    public interface IFavouriteRepository
    {
        Task<List<IFavourite>> GetAsync(string sortOrder = "favouriteId", int pageNumber = 0, int pageSize = 20);
        Task<IFavourite> GetAsync(Guid id);
        Task<int> InsertAsync(IFavourite entity);
        Task<int> UpdateAsync(IFavourite entity);
        Task<int> DeleteAsync(IFavourite entity);
        Task<int> DeleteAsync(Guid id); 
    }
}
