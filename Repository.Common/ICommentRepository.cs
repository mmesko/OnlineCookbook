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
        Task<IEnumerable<IComment>> GetAsync();
        Task<IComment> GetAsync(string id);
        Task<IEnumerable<IComment>> GetRangeAsync(string recipeId, GenericFilter filter);

        Task<int> InsertAsync(IComment entity);

        //Task<int> UpdateAsync(IUnitOfWork unitOfWork, IComment entity);
        Task<int> UpdateAsync(IComment entity);

        Task<int> DeleteAsync(IComment entity);
        Task<int> DeleteAsync(string id);

        //Task<IUnitOfWork> CreateUnitOfWork();
    }
}
