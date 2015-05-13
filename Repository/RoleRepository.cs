using System;
using AutoMapper;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Linq.Dynamic;
using System.Threading.Tasks;
using OnlineCookbook.Repository.Common;
using OnlineCookbook.DAL.Models;
using OnlineCookbook.Model.Common;
using OnlineCookbook.Model;
using OnlineCookbook.Filters.ModelFilter;

namespace OnlineCookbook.Repository
{
    public class RoleRepository :IRoleRepository
    {
        
        protected IRepository Repository { get; private set; }
        //public IUnitOfWork UnitOfWork { get; private set; }

        public RoleRepository(IRepository repository)
        {
            Repository = repository;       
        }

      /*  private IUnitOfWork CreateUnitOfWork()
        {
            return Repository.CreateUnitOfWork();
        }
        */

        public virtual async Task<List<IRole>> GetAsync(RoleFilter filter)
        {
            try
            {
                return Mapper.Map<List<IRole>>(
                    await Repository.WhereAsync<Role>()
                            .OrderBy(filter.SortOrder)
                            .Skip<Role>((filter.PageNumber - 1) * filter.PageSize)
                            .Take<Role>(filter.PageSize)
                            .ToListAsync<Role>()
                    );
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        public virtual async Task<IRole> GetAsync(Guid id)
        {
            try
            {
                return Mapper.Map<IRole>(await Repository.SingleAsync<Role>(id));
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        public virtual Task<int> InsertAsync(IRole entity)
        {
            try
            {
                return Repository.InsertAsync<Role>(Mapper.Map<Role>(entity));
            }
            catch (Exception e)
            {
                throw e;
            }
        }

     
        public virtual Task<int> UpdateAsync(IRole entity)
        {
            try
            {
                return Repository.UpdateAsync<Role>(Mapper.Map<Role>(entity));
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public virtual Task<int> DeleteAsync(IRole entity)
        {
            try
            {
                return Repository.DeleteAsync<Role>(Mapper.Map<Role>(entity));
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
