using System;
using OnlineCookbook.Model.Common;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq.Expressions;


namespace OnlineCookbook.Repository.Common
{
   public interface IUserRepository
    {
        // Get
        Task<IUser> GetAsync(string username);
        Task<IEnumerable<IUser>> GetAsync(Expression<Func<IUser, bool>> match);
        Task<IUser> GetAsync(string username, string password);

        // Add
        Task<int> AddAsync(IUser user);
        Task<bool> RegisterUser(IUser user, string password);

        // Update
        Task<int> UpdateAsync(IUser user);
        Task<IUser> UpdateUserAsync(IUser user, string password);
        Task<IUser> UpdateUserEmailOrUsernameAsync(IUser user, string password);
        Task<bool> UpdateUserPasswordAsync(string userId, string oldPassword, string newPassword);

        // Delete
        Task<int> DeleteAsync(IUser user);
        Task<int> DeleteAsync(string id);


    }
}
