using System;
using AutoMapper;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using OnlineCookbook.Repository.Common;
using OnlineCookbook.DAL.Models;
using OnlineCookbook.Model.Common;
using OnlineCookbook.Model;
using System.Linq.Dynamic;
using OnlineCookbook.Common.Filters;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Linq.Expressions;

namespace OnlineCookbook.Repository
{
    public class UserRepository : IUserRepository
    {
        private IRepository repository;
        private PasswordHasher hasher;
        private UserManager<User> userManager;

        /// <summary>
        /// Constructor
        /// </summary>
        public UserRepository(IRepository repository)
        {
            this.repository = repository;
            hasher = new PasswordHasher();
            userManager = new UserManager<User>(new UserStore<User>(new CookBookContext()));
        }

        /// <summary>
        ///  Get by id
        /// </summary>
        public async Task<Model.Common.IUser> GetAsync(string username)
        {
            try
            {
                return Mapper.Map<Model.Common.IUser>(
                    await repository.GetAsync<User>(c => c.UserName == username)
                    );
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        /// <summary>
        /// Get all entites
        /// </summary>
        public async Task<IEnumerable<Model.Common.IUser>> GetAsync(Expression<Func<Model.Common.IUser, bool>> match)
        {
            try
            {
                return Mapper.Map<IEnumerable<Model.Common.IUser>>(
                    await repository.GetRangeAsync<User>());
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
                using (UserManager<User> userManager = manager())
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
        /// Delete user
        /// </summary>
        public virtual Task<int> DeleteAsync(Model.Common.IUser user)
        {
            try
            {
                return repository.DeleteAsync<User>
                    (Mapper.Map<User>(user));
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Delete by id
        /// </summary>
        public virtual Task<int> DeleteAsync(string id)
        {
            try
            {
                return repository.DeleteAsync<User>(id);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Registers adds user
        /// </summary>
        /// <param name="user"></param>
        /// <returns>True if success, false otherwise</returns>
        public async Task<bool> RegisterUser(Model.Common.IUser user)
        {
            try
            {
                IdentityResult result = await userManager.CreateAsync(
                    Mapper.Map<User>(user), user.PasswordHash);
                return result.Succeeded;
            }
            catch (Exception ex)
            {

                throw ex.InnerException;
            }
        }

        public Task<IUnitOfWork> CreateUnitOfWork()
        {
            try
            {
                return Task.FromResult<IUnitOfWork>(repository.CreateUnitOfWork());
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<int> UpdateAsync(Model.Common.IUser user, string password)
        {
            try
            {
                IdentityResult validation = await userManager.PasswordValidator.ValidateAsync(password);

                if (validation.Succeeded)
                {
                    user.PasswordHash = hasher.HashPassword(user.PasswordHash);

                    return await repository.UpdateAsync<User>(Mapper.Map<User>(user));
                }

                return 0;
            }
            catch (Exception ex)
            {

                throw ex.InnerException;
            }
        }

        /// <summary>
        /// Updates only user name and password proporites
        /// </summary>
        public async Task<int> UpdateEmailOrUsernameAsync(Model.Common.IUser user, string password)
        {
            try
            {
                IdentityResult validation = await userManager.PasswordValidator.ValidateAsync(password);

                if (validation.Succeeded)
                {
                    user.PasswordHash = hasher.HashPassword(user.PasswordHash);

                    // Only allows user name or email to change
                    return await repository.UpdateAsync<User>(
                        Mapper.Map<User>(user), u => u.Email, u => u.UserName
                        );
                }

                return 0;
            }
            catch (Exception ex)
            {

                throw ex.InnerException;
            }

        }

      
        /// <summary>
        /// User manager initialize
        /// </summary>
        /// <returns>new user manager</returns>
        private UserManager<User> manager()
        {
            return new UserManager<User>(new UserStore<User>(new CookBookContext()));
        } 
    }

 }


