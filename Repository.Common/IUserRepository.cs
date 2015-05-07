using System;
using System.Linq;
using System.Collections.Generic;
using OnlineCookbook.Model.Common;
using System.Threading.Tasks;

namespace OnlineCookbook.Repository.Common
{
    public interface IUserRepository
    {
        Task<List<IUser>> GetAsync(string sortOrder = "userId", int pageNumber = 0, int pageSize = 20);
        Task<IUser> GetAsync(Guid id);
        Task<int> InsertAsync(IUser entity);
        Task<int> UpdateAsync(IUser entity);
        Task<int> DeleteAsync(IUser entity);
        Task<int> DeleteAsync(Guid id);
    }
}
