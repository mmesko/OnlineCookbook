using System;
using System.Linq;
using System.Collections.Generic;
using OnlineCookbook.Model.Common;
using System.Threading.Tasks;

namespace OnlineCookbook.Repository.Common
{
    public interface ICategoryRepository
    {
        Task<List<ICategory>> GetAsync(string sortOrder = "categoryId", int pageNumber = 0, int pageSize = 50);
        Task<ICategory> GetAsync(Guid id);
        Task<int> InsertAsync(ICategory entity);
        Task<int> UpdateAsync(ICategory entity);
        Task<int> DeleteAsync(ICategory entity);
        Task<int> DeleteAsync(Guid id); 

    }
}
