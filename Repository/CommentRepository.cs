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


        public virtual async Task<IEnumerable<IComment>> GetAsync()
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
                return Repository.InsertAsync<Comment>(
                    Mapper.Map<Comment>(entity));
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        //public async Task<List<IComment>> AddCommentsAsync(string recipeId)
        //{

        //    try
        //    {
        //        return Mapper.Map<List<IComment>>(
        //             await Repository.WhereAsync<Comment>()
        //             .Where<Comment>(item => item.RecipeId == recipeId)
        //             .ToListAsync<Comment>()
        //             );

        //    }
        //    catch (Exception e)
        //    {
        //        throw e;
        //    }
        
        //}
        public async Task<IEnumerable<IComment>> GetRangeAsync(string recipeId, GenericFilter filter)
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

        //public virtual Task<int> UpdateAsync(IUnitOfWork unitOfWork, IComment entity)
        //{
        //    try
        //    {
        //        return unitOfWork.UpdateAsync<Comment>(
        //            Mapper.Map<Comment>(entity));
        //    }

        //    catch (Exception e)
        //    {
        //        throw e;
        //    }
        //}

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
