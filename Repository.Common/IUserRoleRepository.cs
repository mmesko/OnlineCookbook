using System;
using System.Linq;
using System.Collections.Generic;
using OnlineCookbook.Model.Common;
using System.Threading.Tasks;

namespace OnlineCookbook.Repository.Common
{
    public interface IUserRoleRepository
    {
        Task<List<IUserRole>> GetAsync(string sortOrder = "userRoleId", int pageNumber = 0, int pageSize = 20);
        Task<IUserRole> GetAsync(Guid id);
        Task<int> InsertAsync(IUserRole entity);
        Task<int> UpdateAsync(IUserRole entity);
        Task<int> DeleteAsync(IUserRole entity);
        Task<int> DeleteAsync(Guid id);
    }
}
