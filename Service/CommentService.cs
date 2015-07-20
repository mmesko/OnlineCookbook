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


        public async Task<IEnumerable<IComment>> GetRangeAsync(string recipeId, GenericFilter filter)
        {
            return await Repository.GetRangeAsync(recipeId, filter);
        }

        public async Task<int> InsertAsync(IComment comment)
        {
            return await Repository.InsertAsync(comment);
        }
 
    }
}
