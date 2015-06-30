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
        protected IRepository Repository { get; private set; }
        private PasswordHasher hasher;
        private UserManager<User> userManager;
       

        public UserRepository(IRepository repository)
        {
            Repository = repository;
            hasher = new PasswordHasher();
            userManager = new UserManager<User>
                (new UserStore<User>(new CookBookContext()));
        }


        //bc username is unique 
        public async Task<Model.Common.IUser> GetAsync(string username)
        {
            try
            {
                return Mapper.Map<Model.Common.IUser>(
                    await Repository.GetAsync<User>(c => c.UserName == username));
            }
            catch (Exception e)
            {

                throw e;
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
                    await Repository.GetRangeAsync<User>());
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        /// <summary>
        /// Find user by username and password
        /// </summary>
        public async Task<Model.Common.IUser> GetAsync(string username, string password)
        {
            try
            {
                User user = await userManager.FindAsync(username, password);
                return Mapper.Map<Model.Common.IUser>(user);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> AddAsync(Model.Common.IUser entity)
        {
            try
            {
                return await Repository.AddAsync<User>(Mapper.Map<User>(entity));
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        public async Task<bool> UpdateAsync(Model.Common.IUser entity, string password)
        {
            try
            {
                IdentityResult validation = await userManager.PasswordValidator.ValidateAsync(password);

                if (validation.Succeeded)
                {
                    IdentityResult result = await userManager.UpdateAsync(Mapper.Map<User>(entity));
                    bool success = result.Succeeded;

                    return success;
                }

                return false;
            }
            catch (Exception e)
            {

                throw e;
            }

        }

        public virtual Task<int> DeleteAsync(Model.Common.IUser entity)
        {
            try
            {
                return Repository.DeleteAsync<User>(Mapper.Map<User>(entity));
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public virtual Task<int> DeleteAsync(string id)
        {
            try
            {
                return Repository.DeleteAsync<User>(id);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<bool> RegisterUser(Model.Common.IUser entity)
        {
            try
            {
                IdentityResult result = await userManager.CreateAsync(
                    Mapper.Map<User>(entity), entity.PasswordHash);

                return result.Succeeded;
            }
            catch (Exception e)
            {

                throw e.InnerException;
            }
        }


        public Task<IUnitOfWork> CreateUnitOfWork()
        {
            try
            {
                return Task.FromResult<IUnitOfWork>(Repository.CreateUnitOfWork());
            }
            catch (Exception e)
            {

                throw e;
            }
        }
    }

 }


