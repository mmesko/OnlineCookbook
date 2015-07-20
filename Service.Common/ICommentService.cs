using System.Collections.Generic;
using OnlineCookbook.Model.Common;
using System.Threading.Tasks;
using OnlineCookbook.Common.Filters;


namespace OnlineCookbook.Service.Common
{
    public interface ICommentService
    {
        Task<IEnumerable<IComment>> GetRangeAsync(string recipeId, GenericFilter filter);

        Task<int> InsertAsync(IComment entity);
  
        //Task<int> UpdateAsync(IComment entity);

        //Task<int> DeleteAsync(IComment entity);
        //Task<int> DeleteAsync(string id);

    }
}
