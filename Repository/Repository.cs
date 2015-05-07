using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Threading.Tasks;
using OnlineCookbook.DAL.Models;
using OnlineCookbook.Repository.Common;


namespace OnlineCookbook.Repository
{
    public class Repository : IRepository
    {

        protected ICookBookContext DbContext { get; private set; }
        protected IUnitOfWorkFactory UnitOfWorkFactory { get; private set; }

        public Repository(ICookBookContext dbContext, IUnitOfWorkFactory unitOfWorkFactory)
        {
            if (dbContext == null)
            {
                throw new ArgumentNullException("DbContext");
            }
            DbContext = dbContext;
            UnitOfWorkFactory = unitOfWorkFactory;
        }


        public IUnitOfWork CreateUnitOfWork() //sprema kao instancu IUoW
        {
            return UnitOfWorkFactory.CreateUnitOfWork();
        }

        public virtual IQueryable<T> WhereAsync<T>() where T : class
        {
            return DbContext.Set<T>().AsNoTracking();
        }


        public virtual Task<T> SingleAsync<T>(Guid id) where T : class
        {
            return DbContext.Set<T>().FindAsync(id);
        }

        public virtual async Task<int> InsertAsync<T>(T entity) where T : class
        {

            DbEntityEntry dbEntityEntry = DbContext.Entry(entity);
            if (dbEntityEntry.State != EntityState.Detached)
            {
                dbEntityEntry.State = EntityState.Added;
            }
            else
            {
                DbContext.Set<T>().Add(entity);
            }

            try
            {
                return await DbContext.SaveChangesAsync();
            }

            catch(Exception e)
            {
                throw e;
            }
        }

        public virtual async Task<int> UpdateAsync<T>(T entity) where T : class
        {
            DbEntityEntry dbEntityEntry = DbContext.Entry(entity);
            if (dbEntityEntry.State == EntityState.Detached)
            {
                DbContext.Set<T>().Attach(entity);
            }
            dbEntityEntry.State = EntityState.Modified;

            try
            {
                return await DbContext.SaveChangesAsync();
            }

            catch (Exception e)
            {
                throw e;
            }
        }

        public virtual async Task<int> DeleteAsync<T>(T entity) where T : class
        {
            DbEntityEntry dbEntityEntry = DbContext.Entry(entity);
            if (dbEntityEntry.State != EntityState.Deleted)
            {
                dbEntityEntry.State = EntityState.Deleted;
            }
            else
            {
                DbContext.Set<T>().Attach(entity);
                DbContext.Set<T>().Remove(entity);
            }

            try
            {
                return await DbContext.SaveChangesAsync();
            }

            catch (Exception e)
            {
                throw e;
            }
        }

        public virtual async Task<int> DeleteAsync<T>(Guid id) where T : class
        {
            var entity = await  SingleAsync<T>(id);
            if (entity == null)
            {
                throw new DllNotFoundException();//find throw exception
            }
            return await DeleteAsync(entity);         
        }
    }
}
