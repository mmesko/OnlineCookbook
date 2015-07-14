using System.Collections.Generic;
using OnlineCookbook.Model.Common;
using System.Threading.Tasks;
using OnlineCookbook.Common.Filters;


namespace OnlineCookbook.Service.Common
{
    public interface ICommentService
    {
        Task<List<IComment>> GetAsync(CommentFilter filter = null);
        Task<IComment> GetAsync(string id);
        Task<List<IComment>> GetCommentsAsync(string recipeId);

        Task<int> InsertAsync(IComment entity);
  
        Task<int> UpdateAsync(IComment entity);

        Task<int> DeleteAsync(IComment entity);
        Task<int> DeleteAsync(string id);

    }
}
