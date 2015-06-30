using System;
using System.Linq;
using System.Collections.Generic;
using OnlineCookbook.Model.Common;
using System.Threading.Tasks;
using OnlineCookbook.Common.Filters;
using System.Linq.Expressions;


namespace OnlineCookbook.Repository.Common
{
    public interface IUserRepository
    {

        Task<IUser> GetAsync(string username);

        Task<IEnumerable<IUser>> GetAsync(Expression<Func<IUser, bool>> match);
        Task<int> AddAsync(IUser entity);
        Task<bool> UpdateAsync(IUser entity, string password);
        Task<int> DeleteAsync(IUser entity);
        Task<int> DeleteAsync(string id);
        Task<bool> RegisterUser(IUser entity);
        Task<IUser> GetAsync(string username, string password);
        Task<IUnitOfWork> CreateUnitOfWork();
    }
}
