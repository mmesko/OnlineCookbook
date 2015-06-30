using System;
using System.Linq;
using System.Collections.Generic;
using OnlineCookbook.Model.Common;
using System.Threading.Tasks;

namespace OnlineCookbook.Repository.Common
{
    public interface IFavouriteUserRepository
    {
        Task<List<IFavouriteUser>> GetAsync(string sortOrder = "favouriteUserId", int pageNumber = 0, int pageSize = 20);
        Task<IFavouriteUser> GetAsync(string id);
        Task<int> InsertAsync(IFavouriteUser entity);
        Task<int> UpdateAsync(IFavouriteUser entity);
        Task<int> DeleteAsync(IFavouriteUser entity);
        Task<int> DeleteAsync(string id); 
    }
}
