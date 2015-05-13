using System;
using System.Linq;
using System.Collections.Generic;
using OnlineCookbook.Model.Common;
using System.Threading.Tasks;
using OnlineCookbook.Filters.ModelFilter;


namespace OnlineCookbook.Repository.Common
{
    public interface IUserRepository
    {
        Task<List<IUser>> GetAsync(UserFilter filter);
        Task<IUser> GetAsync(Guid id);
        Task<int> InsertAsync(IUser entity);
        Task<int> UpdateAsync(IUser entity);
        Task<int> DeleteAsync(IUser entity);
        Task<int> DeleteAsync(Guid id);
    }
}
