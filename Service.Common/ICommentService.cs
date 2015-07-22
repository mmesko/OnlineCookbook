using System.Collections.Generic;
using OnlineCookbook.Model.Common;
using System.Threading.Tasks;
using OnlineCookbook.Common.Filters;


namespace OnlineCookbook.Service.Common
{
    public interface ICommentService
    {
        Task<IEnumerable<IComment>> GetAsync(string recipeId, GenericFilter filter);
        Task<IComment> InsertAsync(IComment entity);
        Task<IComment> UpdateAsync(IComment entity);
        Task<int> DeleteAsync(string id);
    }
}
