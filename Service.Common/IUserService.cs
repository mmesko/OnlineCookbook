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
        Task<int> UpdateEmailOrUsernameAsync(Model.Common.IUser user, string password);
    }
}
