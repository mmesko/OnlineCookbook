using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OnlineCookbook.Model.Common;
using System.Threading.Tasks;
using OnlineCookbook.Filters.ModelFilter;

namespace OnlineCookbook.Service.Common
{
     public interface IRoleService 
    {
        Task<List<IRole>> GetAsync(RoleFilter filter);
        Task<IRole> GetAsync(Guid id);

        Task<int> InsertAsync(IRole entity);

        Task<int> UpdateAsync(IRole entity);

        Task<int> DeleteAsync(IRole entity);
        Task<int> DeleteAsync(Guid id);
    }
}
