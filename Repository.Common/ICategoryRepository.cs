using System;
using System.Linq;
using System.Collections.Generic;
using OnlineCookbook.Model.Common;
using System.Threading.Tasks;
using OnlineCookbook.Common.Filters;

namespace OnlineCookbook.Repository.Common
{
    public interface ICategoryRepository
    {
        Task<List<ICategory>> GetAsync(CategoryFilter filter = null);
        Task<ICategory> GetAsync(string id);
        Task<int> InsertAsync(ICategory entity);
        Task<int> UpdateAsync(ICategory entity);
        Task<int> DeleteAsync(ICategory entity);
        Task<int> DeleteAsync(string id); 

    }
}
