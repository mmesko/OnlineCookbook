using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using OnlineCookbook.Model.Common;


namespace OnlineCookbook.Service.Common
{
    public interface IUserService
    {
        Task<IUser> FindAsync(string username);
        Task<IUser> FindAsync(string username, string password);
        Task<bool> RegisterUser(IUser user);
        Task<bool> UpdateAsync(IUser user, string password);
    }
}
