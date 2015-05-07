using System;
using System.Linq;
using System.Collections.Generic;
using OnlineCookbook.Model.Common;
using System.Threading.Tasks;

namespace OnlineCookbook.Repository.Common
{
   public interface IRoleRepository
    {
       Task<List<IRole>> GetAsync(string sortOrder = "roleId", int pageNumber = 0, int pageSize = 20);
       Task<IRole> GetAsync(Guid id);
       Task<int> InsertAsync(IRole entity);
       Task<int> UpdateAsync(IRole entity);
       Task<int> DeleteAsync(IRole entity);
       Task<int> DeleteAsync(Guid id);
    }
}
