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

           public virtual Task<int> AddAsync<T>(T entity) where T : class
           {
               try
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
                   return Task.FromResult(1);
               }
               catch (Exception e)
               {
                   throw e;
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

           public virtual Task<int> DeleteAsync<T>(int id) where T : class
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
                   //storing everithing added in DbContext
                   result = await DbContext.SaveChangesAsync();
                   scope.Complete(); //sacuvano u bazi
               }
               return result;
           }

           public void Dispose()
           {
               DbContext.Dispose();
           }
       }

    
}
