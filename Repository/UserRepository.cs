using AutoMapper;
using OnlineCookbook.DAL;
using OnlineCookbook.DAL.Models;
using OnlineCookbook.Repository.Common;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineCookbook.Repository
{
    public class UserRepository : IUserRepository
    {
        private IRepository repository;
        private PasswordHasher hasher;

        /// <summary>
        /// Constructor
        /// </summary>
        public UserRepository(IRepository repository)
        {
            this.repository = repository;
            hasher = new PasswordHasher();
        }

        #region Other methods

        /// <summary>
        /// Initalize user manager
        /// </summary>
        /// <returns>new user manager</returns>
        private UserManager<User> createUserManager()
        {
            return new UserManager<User>(new UserStore<User>(new CookBookContext()));
        }

        #endregion

        #region Get

        /// <summary>
        ///  Get by id
        /// </summary>
        public async Task<Model.Common.IUser> GetAsync(string username)
        {
            try
            {
                return Mapper.Map<Model.Common.IUser>(await repository.GetAsync<User>(c => c.UserName == username));
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        /// <summary>
        /// Get all entites
        /// </summary>
        public async Task<IEnumerable<Model.Common.IUser>> GetAsync(System.Linq.Expressions.Expression<Func<Model.Common.IUser, bool>> match)
        {
            try
            {
                return Mapper.Map<IEnumerable<Model.Common.IUser>>(await repository.GetRangeAsync<User>());
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// Find user by username and password
        /// </summary>
        public async Task<Model.Common.IUser> GetAsync(string username, string password)
        {
            try
            {
                User user;
                using (UserManager<User> userManager = createUserManager())
                {
                    user = await userManager.FindAsync(username, password);
                }
                return Mapper.Map<Model.Common.IUser>(user);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Add

        /// <summary>
        /// Add user
        /// </summary>
        public async Task<int> AddAsync(Model.Common.IUser user)
        {
            try
            {
                return await repository.AddAsync<User>(Mapper.Map<User>(user));
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// Registers adds user
        /// </summary>
        /// <param name="user"></param>
        /// <returns>True if success, false otherwise</returns>
        public async Task<bool> RegisterUser(Model.Common.IUser user, string password)
        {
            try
            {
                using (UserManager<User> userManager = createUserManager())
                {
                    IdentityResult result = await userManager.CreateAsync(Mapper.Map<User>(user), password);
                    return result.Succeeded;
                }
            }
            catch (Exception ex)
            {

                throw ex.InnerException;
            }
        }
        #endregion

        #region Delete

        /// <summary>
        /// Delete user
        /// </summary>
        public async Task<int> DeleteAsync(Model.Common.IUser user)
        {
            try
            {
                return await repository.DeleteAsync<User>(Mapper.Map<User>(user));
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// Delete by id
        /// </summary>
        public async Task<int> DeleteAsync(string id)
        {
            try
            {
                return await this.DeleteAsync(Mapper.Map<Model.Common.IUser>
                    (await repository.DeleteAsync<User>(id)));
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        #endregion

        #region  Update

        /// <summary>
        /// Updates user, return int as result
        /// </summary>
        /// <param name="user">User</param>
        /// <param name="password">User password for validation</param>
        /// <returns>Int { 0: operation failed }</returns>
        public async Task<int> UpdateAsync(Model.Common.IUser user)
        {
            try
            {
                return await repository.UpdateAsync<User>(Mapper.Map<User>(user));
            }
            catch (Exception ex)
            {

                throw ex.InnerException;
            }
        }

        /// <summary>
        /// Updates user and return updated user
        /// </summary>
        /// <param name="user">User to update</param>
        /// <param name="password">User password</param>
        /// <returns>IUser</returns>
        public async Task<Model.Common.IUser> UpdateUserAsync(Model.Common.IUser user, string password)
        {
            try
            {
                IUnitOfWork uow = repository.CreateUnitOfWork();
                bool passwordValid = false;
                Task<User> result = null;

                // Check if user is valid
                using (UserManager<User> UserManager = createUserManager())
                {
                    User userToCheck = await UserManager.FindByIdAsync(user.Id);
                    passwordValid = await UserManager.CheckPasswordAsync(userToCheck, password);
                }

                if (passwordValid)
                    result = uow.UpdateObjectAsync<User>(Mapper.Map<User>(user));

                await uow.CommitAsync();
                return await Task.FromResult(Mapper.Map<Model.Common.IUser>(result.Result) as Model.Common.IUser);
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Updates only username or email
        /// </summary>
        /// <param name="user">UserToUpdate</param>
        /// <param name="password">User password</param>
        /// <returns>IUser</returns>
        public async Task<Model.Common.IUser> UpdateUserEmailOrUsernameAsync(Model.Common.IUser user, string password)
        {
            try
            {
                IUnitOfWork uow = repository.CreateUnitOfWork();
                bool passwordValid = false;
                Task<User> result = null;

                // Check if user is valid
                using (UserManager<User> UserManager = createUserManager())
                {
                    User userToCheck = await UserManager.FindByIdAsync(user.Id);
                    passwordValid = await UserManager.CheckPasswordAsync(userToCheck, password);
                }

                if (passwordValid)
                    result = uow.UpdateAsync<User>(Mapper.Map<User>(user), u => u.Email, u => u.UserName);

                await uow.CommitAsync();
                return await Task.FromResult(Mapper.Map<Model.Common.IUser>(result.Result) as Model.Common.IUser);
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Change user password
        /// </summary>
        /// <param name="user">User </param>
        /// <param name="newPassword">New password</param>
        /// <returns>IUser</returns>
        public async Task<bool> UpdateUserPasswordAsync(string userId, string oldPassword, string newPassword)
        {
            try
            {

                IdentityResult result;
                using (UserManager<User> UserManager = createUserManager())
                {
                    result = await UserManager.ChangePasswordAsync(userId, oldPassword, newPassword);
                }

                return result.Succeeded;
            }
            catch (Exception)
            {

                throw;
            }
        }

        #endregion



    }
}

