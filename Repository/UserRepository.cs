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
using OnlineCookbook.Filters.ModelFilter;

namespace OnlineCookbook.Repository
{
    public class UserRepository : IUserRepository
    {
        protected IRepository Repository { get; private set; }
        public IUnitOfWork UnitOfWork { get; private set; }

        public UserRepository(IRepository repository)
        {
            Repository = repository;
        }

        public IUnitOfWork CreateUnitOfWork()
        {
            return Repository.CreateUnitOfWork();
        }

        public virtual async Task<List<IUser>> GetAsync(UserFilter filter)
        {
            try
            {    return Mapper.Map<List<IUser>>(
                         await Repository.WhereAsync<User>() 
                            .OrderBy(filter.SortOrder)
                            .Skip<User>((filter.PageNumber - 1) * filter.PageSize)
                            .Take<User>(filter.PageSize) //whole page
                            .ToListAsync<User>()
                     );
            }
            catch (Exception e)
            {
                throw e;
            }       
        }


        public virtual async Task<IUser> GetAsync(Guid id)
        {
            try
            {
                return Mapper.Map<IUser>(await Repository.SingleAsync<User>(id));
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        public virtual Task<int> InsertAsync(IUser entity)
        {
            try
            {
                return Repository.InsertAsync<User>(Mapper.Map<User>(entity));
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        public virtual Task<int> UpdateAsync(IUser entity)
        {
            try
            {
                return Repository.UpdateAsync<User>(Mapper.Map<User>(entity));
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public virtual Task<int> DeleteAsync(IUser entity)
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

        public virtual Task<int> DeleteAsync(Guid id)
        {
            try
            {
                return Repository.DeleteAsync<Role>(id);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }

 }


