using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using OnlineCookbook.Model.Common;
using OnlineCookbook.Repository.Common;
using OnlineCookbook.Service.Common;
using OnlineCookbook.Common.Filters;

namespace OnlineCookbook.Service
{
    public class CommentService : ICommentService
    {
        protected ICommentRepository Repository { get; private set; }

        public CommentService(ICommentRepository repository)
        {
            Repository = repository;
        }

        public Task<List<IComment>> GetAsync(CommentFilter filter = null)
        {
            try
            {
                return Repository.GetAsync(filter);
            }
            catch (Exception e)
            {
                throw e;
            }

        }


        public Task<IComment> GetAsync(string id)
        {
            try
            {
                return Repository.GetAsync(id);
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        public Task<List<IComment>> GetCommentsAsync(string recipeId)
        {

            try
            {
                return Repository.GetCommentsAsync(recipeId);
            }
            catch (Exception e)
            {
                throw e;
            }
        
        }

        public Task<int> InsertAsync(IComment entity)
        {
            try
            {
                return Repository.InsertAsync(entity);
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        public Task<int> UpdateAsync(IComment entity)
        {
            try
            {
                return Repository.UpdateAsync(entity);
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        public Task<int> DeleteAsync(IComment entity)
        {
            try
            {
                return Repository.DeleteAsync(entity);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Task<int> DeleteAsync(string id)
        {
            try
            {
                return Repository.DeleteAsync(id);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

 
    }
}
