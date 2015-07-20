using OnlineCookbook.Model.Common;
using OnlineCookbook.Repository.Common;
using OnlineCookbook.Service.Common;
using System;
using System.Threading.Tasks;

namespace OnlineCookbook.Service
{
    public class UserService : IUserService
    {
        public IUserRepository Repository { get; private set; }

        public UserService(IUserRepository repository)
        {
            Repository = repository;
        }

        public async Task<IUser> FindAsync(string username)
        {
            try
            {
                return await Repository.GetAsync(username);
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public async Task<IUser> FindAsync(string username, string password)
        {
            try
            {
                return await Repository.GetAsync(username, password);
            }
            catch (Exception e)
            {

                throw e;
            }
        }


        public async Task<bool> RegisterUser(Model.Common.IUser user, string password)
        {
            try
            {
                return await Repository.RegisterUser(user, password);
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public async Task<Model.Common.IUser> UpdateEmailOrUsernameAsync(Model.Common.IUser user, string password)
        {

            try
            {
                return await Repository.UpdateUserEmailOrUsernameAsync(user, password);
            }
            catch (Exception e)
            {

                throw e;
            }
           
        }

        public async Task<bool> UpdatePasswordAsync(string userId, string oldPassword, string newPassword)
        {
            try
            {
                return await Repository.UpdateUserPasswordAsync(userId, oldPassword, newPassword);
            }
            catch (Exception e)
            {

                throw e;
            }
            
        }
    }
}