using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Threading.Tasks;
using OnlineCookbook.DAL.Models;
using System.Transactions;


namespace OnlineCookbook.Repository
{
      //CommitAsync calls SaveChanges()
       public class UnitOfWork : IUnitOfWork
       {
           protected ICookBookContext DbContext { get; private set; }

           public UnitOfWork(ICookBookContext dbContext)
           {
               if (dbContext == null)
               {
                   throw new ArgumentNullException("DbContext");
               }
               DbContext = dbContext;
           }

           public virtual Task<T> AddAsync<T>(T entity) where T : class
           {
               try
               {
                   DbEntityEntry dbEntity = DbContext.Entry(entity);
                   if (dbEntity.State != EntityState.Detached)
                   {
                       dbEntity.State = EntityState.Added;
                   }
                   else
                   {
                       DbContext.Set<T>().Add(entity);
                   }
                   return Task.FromResult(dbEntity.Entity as T);
               }
               catch (Exception)
               {
                   throw;
               }

           }

           public virtual Task<int> UpdateAsync<T>(T entity) where T : class
           {
               try
               {
                   DbEntityEntry dbEntityEntry = DbContext.Entry(entity);
                   if (dbEntityEntry.State == EntityState.Detached)
                   {
                       DbContext.Set<T>().Attach(entity);
                   }
                   dbEntityEntry.State = EntityState.Modified;
                   return Task.FromResult(1);
               }
               catch (Exception e)
               {
                   throw e;
               }

           }

           /// <summary>
           /// Update without adding new entites
           /// </summary>
           public virtual Task<T> UpdateWithAttachAsync<T>(T entity) where T : class
           {
               try
               {
                   DbEntityEntry entry = DbContext.Entry<T>(entity);
                   entry.State = EntityState.Modified;

                   return Task.FromResult(entry.Entity as T);
               }
               catch (Exception ex)
               {

                   throw ex;
               }
           }


           /// <summary>
           /// Updates entity, commit should be called afterwards to save changes
           /// </summary>
           /// <returns>T entity</returns
           public virtual Task<T> UpdateObjectAsync<T>(T entity) where T : class
           {
               try
               {
                   DbEntityEntry entityEntry = DbContext.Entry<T>(entity);
                   DbContext.Set<T>().Add(entity);
                   entityEntry.State = EntityState.Modified;

                   return Task.FromResult<T>(entityEntry.Entity as T);
               }
               catch (Exception e)
               {
                   throw e;
               }
           }

           public virtual Task<T> UpdateAsync<T>(T entity, params Expression<Func<T, object>>[] entityParameters) where T : class
           {
               try
               {
                   DbEntityEntry entry = DbContext.Entry<T>(entity);
                   DbContext.Set<T>().Add(entity);
                   entry.State = EntityState.Unchanged;
                   foreach (var p in entityParameters)
                   {
                       DbContext.Entry<T>(entity).Property(p).IsModified = true;
                   }

                   return Task.FromResult(entry.Entity as T);
               }
               catch (Exception e)
               {

                   throw e;
               }
           }

           public virtual Task<int> DeleteAsync<T>(T entity) where T : class
           {
               try
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
                   return Task.FromResult(1);
               }
               catch (Exception e)
               {
                   throw e;
               }

           }

           public virtual Task<int> DeleteAsync<T>(string id) where T : class
           {
               var entity = DbContext.Set<T>().Find(id);
               if (entity == null)
               {
                   return Task.FromResult(0);
               }
               return DeleteAsync<T>(entity);
           }

           public async Task<int> CommitAsync()
           {
               int result = 0;
               using (TransactionScope scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
               {
                   //one transaction using one time
                   //storing everything added in DbContext
                   result = await DbContext.SaveChangesAsync();
                   scope.Complete(); //saved in DB 
               }
               return result;
           }


           /// <summary>
           /// Save changes to database
     


           public void Dispose()
           {
               DbContext.Dispose();
           }
       }

    
}
