using System;
using AutoMapper;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Dynamic;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using OnlineCookbook.Repository.Common;
using OnlineCookbook.DAL.Models;
using OnlineCookbook.Model.Common;
using OnlineCookbook.Model;
using OnlineCookbook.Common.Filters;

namespace OnlineCookbook.Repository
{
   public class CommentRepository : ICommentRepository 
    {
       protected IRepository Repository { get; private set; }

        public CommentRepository(IRepository repository)
        {
            Repository = repository;
        }


        public virtual async Task<List<IComment>> GetAsync(CommentFilter filter = null)
        {
            try
            {
                if (filter != null)
                {
                    return Mapper.Map<List<IComment>>(
                        await Repository.WhereAsync<Comment>()
                                 .OrderBy(filter.SortOrder)
                                 .Skip<Comment>((filter.PageNumber - 1) * filter.PageSize)
                                 .Take<Comment>(filter.PageSize)
                                 .ToListAsync<Comment>()
                                 );
                }
                else // return all
                {
                    return Mapper.Map<List<IComment>>(
                        await Repository.WhereAsync<Comment>()
                        .ToListAsync()
                        );
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public virtual async Task<IComment> GetAsync(string id)
        {
            try
            {
                return Mapper.Map<IComment>(
                    await Repository.SingleAsync<Comment>(id));
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public virtual Task<int> InsertAsync(IComment entity)
        {
            try
            {
                return Repository.InsertAsync<Comment>(
                    Mapper.Map<Comment>(entity));
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<List<IComment>> AddCommentsAsync(string recipeId)
        {

            try
            {
                return Mapper.Map<List<IComment>>(
                     await Repository.WhereAsync<Comment>()
                     .Where<Comment>(item => item.RecipeId == recipeId)
                     .ToListAsync<Comment>()
                     );

            }
            catch (Exception e)
            {
                throw e;
            }
        
        }
        public async Task<List<IComment>> GetCommentsAsync(string recipeId)
        { 
           try
           {
               return Mapper.Map<List<IComment>>(
                    await Repository.WhereAsync<Comment>()
                    .Where<Comment>(item => item.RecipeId == recipeId)
                    .ToListAsync<Comment>()
                    );

             }
            catch(Exception e)
           {
             throw e;
           }


        }

        public virtual Task<int> UpdateAsync(IUnitOfWork unitOfWork, IComment entity)
        {
            try
            {
                return unitOfWork.UpdateAsync<Comment>(
                    Mapper.Map<Comment>(entity));
            }

            catch (Exception e)
            {
                throw e;
            }
        }

        public virtual Task<int> UpdateAsync(IComment entity)
        {
            try
            {
                return Repository.UpdateAsync<Comment>(Mapper.Map<Comment>(entity));
            }

            catch (Exception e)
            {
                throw e;
            }
        }

        public virtual Task<int> DeleteAsync(IComment entity)
        {
            try
            {
                
                return Repository.DeleteAsync<Comment>(Mapper.Map<Comment>(entity));
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
                return Repository.DeleteAsync<Comment>(Mapper.Map<Comment>(id));
            }

            catch (Exception e)
            {
                throw e;
            }
        }

        public Task<IUnitOfWork> CreateUnitOfWork()
        {
            try
            {
                return Task.FromResult(Repository.CreateUnitOfWork());
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
