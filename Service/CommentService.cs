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


        public async Task<IEnumerable<IComment>> GetAsync(string recipeId, GenericFilter filter)
        {
            try
            {
                return await Repository.GetAsync(recipeId, filter);
            }
          
            catch(Exception e)
            {
                throw e.InnerException;
            }
        }

        public async Task<IComment> InsertAsync(IComment entity)
        {
            try 
            {
                return await Repository.InsertICommentAsync(entity);
            }
            catch (Exception e)
            {
                throw e.InnerException;
            }
            
        }

        /// <summary>
        /// Updates given comment
        /// </summary>
        public async Task<IComment> UpdateAsync(IComment entity)
        {
            try
            {
                return await Repository.UpdateICommentAsync(entity);
            }
            catch (Exception e)
            {
                throw e.InnerException;
            }
            
        }

        /// <summary>
        /// Deletes review by id
        /// </summary>
        public async Task<int> DeleteAsync(string id)
        {
            try
            {
                return await Repository.DeleteAsync(id);
            }
            catch (Exception e)
            {
                throw e.InnerException;
            }
        }
 
    }
}
