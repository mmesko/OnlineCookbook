using OnlineCookbook.Model.Common;
using System.Threading.Tasks;

namespace OnlineCookbook.Service.Common
{
    public interface IUserService
    {
        Task<IUser> FindAsync(string username);
        Task<IUser> FindAsync(string username, string password);
        Task<bool> RegisterUser(IUser user, string password);
        Task<Model.Common.IUser> UpdateEmailOrUsernameAsync(Model.Common.IUser user, string password);
        Task<bool> UpdatePasswordAsync(string userId, string oldPassword, string newPassword);
    }
}