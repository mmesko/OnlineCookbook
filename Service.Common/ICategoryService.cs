using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OnlineCookbook.Model.Common;
using System.Threading.Tasks;
using OnlineCookbook.Common.Filters;

namespace OnlineCookbook.Service.Common
{
     public interface ICategoryService
    {
        Task<List<ICategory>> GetAsync(CategoryFilter filter = null);
        Task<List<ICategory>> GetNameAsync(string name);
        Task<ICategory> GetAsync(string id);
        Task<int> InsertAsync(ICategory entity);
        Task<int> UpdateAsync(ICategory entity);
        Task<int> DeleteAsync(ICategory entity);
        Task<int> DeleteAsync(string id);
    }
}
