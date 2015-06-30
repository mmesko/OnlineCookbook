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
using Ninject.Activation;


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


        public virtual Task<T> SingleAsync<T>(string id) where T : class
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

        public virtual async Task<int> DeleteAsync<T>(string id) where T : class
        {
            var entity = await SingleAsync<T>(id);
            if (entity == null)
            {
                throw new DllNotFoundException();//find throw exception
            }
            return await DeleteAsync(entity);
        }



        //for user
        public async Task<int> AddAsync<T>(T entity) where T : class
        {
            try
            {
               DbContext.Set<T>().Add(entity);
                return await DbContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// Adds collection of entites
        /// </summary>
        /// <param name="listOfEntities">collection</param>
        /// <returns>collection</returns>
        public async Task<int> AddAsync<T>(IEnumerable<T> listOfEntities) where T : class
        {
            try
            {
                DbContext.Set<T>().AddRange(listOfEntities);
                return await DbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<T>> GetRangeAsync<T>() where T : class
        {
            return await DbContext.Set<T>().ToListAsync();
        }

        /// <summary>
        /// Find entity 
        /// </summary>
        /// <param name="match">Expression</param>
        /// <returns>Entity or null</returns>
        public Task<T> GetAsync<T>(Expression<Func<T, bool>> match) where T : class
        {
            return DbContext.Set<T>().FirstAsync(match);
        }

        /// <summary>
        /// Find enties
        /// </summary>
        /// <param name="match">expression</param>
        /// <returns>List of entites or null</returns>
        public async Task<IEnumerable<T>> GetRangeAsync<T>
            (Expression<Func<T, bool>> match) where T : class
        {
            return await DbContext.Set<T>().Where(match).ToListAsync();
        }



        /// Update entity
        /// </summary>
        /// <typeparam name="T">Entity type</typeparam>
        /// <param name="entity">Entity to update</param>
        /// <param name="proportiesToUpdate">Entite proporties to update</param>
        /// <returns>Save changes async</returns>
        public async Task<int> UpdateAsync<T>(T entity, params Expression<Func<T, object>>[] proportiesToUpdate) where T : class
        {
            try
            {
                DbContext.Set<T>().Add(entity);
                foreach (var property in proportiesToUpdate)
                {
                    DbContext.Entry<T>(entity).Property(property).IsModified = true;
                }

                return await DbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
