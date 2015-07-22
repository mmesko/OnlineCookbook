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
        Task<IEnumerable<IComment>> GetAsync(IRecipe entity);
        Task<IComment> GetAsync(string id);
        Task<IComment> UpdateICommentAsync(IComment entity);
        Task<IComment> InsertICommentAsync(IComment entity);
        Task<IEnumerable<IComment>> GetAsync(string recipeId, GenericFilter filter);

        Task<int> InsertAsync(IComment entity);
        Task<int> UpdateAsync(IComment entity);

        Task<int> DeleteAsync(IComment entity);
        Task<int> DeleteAsync(string id);

      
    }
}
