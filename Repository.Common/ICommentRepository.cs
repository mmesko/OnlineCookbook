using System;
using System.Linq;
using System.Collections.Generic;
using OnlineCookbook.Model.Common;
using System.Threading.Tasks;
using OnlineCookbook.Common.Filters;

namespace OnlineCookbook.Repository.Common
{
    public interface ICommentRepository
    {
        Task<List<IComment>> GetAsync(CommentFilter filter = null);
        Task<IComment> GetAsync(string id);
        Task<List<IComment>> GetCommentsAsync(string recipeId); 

        Task<int> InsertAsync(IComment entity);

        Task<int> UpdateAsync(IUnitOfWork unitOfWork, IComment entity);
        Task<int> UpdateAsync(IComment entity);

        Task<int> DeleteAsync(IComment entity);
        Task<int> DeleteAsync(string id);

        Task<IUnitOfWork> CreateUnitOfWork();
    }
}
