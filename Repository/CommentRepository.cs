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


        public virtual async Task<IEnumerable<IComment>> GetAsync(IRecipe entity)
        {
            try
            {
                return Mapper.Map<IEnumerable<IComment>>(
                    await Repository.GetRangeAsync<Comment>());
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
                return Repository.AddAsync<Comment>(
                    Mapper.Map<Comment>(entity));
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Adds comments and updates recipe with raiting
        /// </summary>
        /// <param name="review">Comment</param>
        /// <returns>Comment</returns>
        public async Task<IComment> InsertICommentAsync(IComment entity)
        {
            try
            {
                IUnitOfWork uow = Repository.CreateUnitOfWork();

                Comment result = await uow.AddAsync<Comment>(Mapper.Map<Comment>(entity));

                await uow.CommitAsync();

                return Mapper.Map<IComment>(result);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    
        public async Task<IEnumerable<IComment>> GetAsync(string recipeId, GenericFilter filter)
        {
            try
            {
                if (filter == null)
                    filter = new GenericFilter(1, 5);


                return Mapper.Map<IEnumerable<IComment>>(await
                     Repository.WhereAsync<Comment>()
                    .Where(c => c.RecipeId == recipeId)
                    .OrderBy(item=>item.CommentText) //added date and time in database, do CF for update in mapping 
                    .Skip((filter.PageNumber * filter.PageSize) - filter.PageSize)
                    .Take(filter.PageSize).ToListAsync());

            }
            catch (Exception ex)
            {
                throw ex;
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

        public async Task<IComment> UpdateICommentAsync(IComment entity)
        {
            try
            {
                IUnitOfWork uow = Repository.CreateUnitOfWork();
                Comment result = await uow.UpdateWithAttachAsync<Comment>(
                    AutoMapper.Mapper.Map<Comment>(entity));
                await uow.CommitAsync();

                return AutoMapper.Mapper.Map<IComment>(result);

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

        //public Task<IUnitOfWork> CreateUnitOfWork()
        //{
        //    try
        //    {
        //        return Task.FromResult(Repository.CreateUnitOfWork());
        //    }
        //    catch (Exception e)
        //    {
        //        throw e;
        //    }
        //}
    }
}
