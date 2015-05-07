using System;
using System.Linq;
using System.Collections.Generic;
using OnlineCookbook.Model.Common;
using System.Threading.Tasks;

namespace OnlineCookbook.Repository.Common
{
    public interface ICommentRepository
    {
        Task<List<IComment>> GetAsync(string sortOrder = "commentId", int pageNumber = 0, int pageSize = 20);
        Task<IComment> GetAsync(Guid id);
        Task<int> InsertAsync(IComment entity);
        Task<int> UpdateAsync(IComment entity);
        Task<int> DeleteAsync(IComment entity);
        Task<int> DeleteAsync(Guid id); 
    }
}
