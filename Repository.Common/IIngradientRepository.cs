using System;
using System.Linq;
using System.Collections.Generic;
using OnlineCookbook.Model.Common;
using System.Threading.Tasks;

namespace OnlineCookbook.Repository.Common
{
    public interface IIngradientRepository
    {
        Task<List<IIngradient>> GetAsync(string sortOrder = "ingradientId", int pageNumber = 0, int pageSize = 20);
        Task<IIngradient> GetAsync(Guid id);
        Task<int> InsertAsync(IIngradient entity);
        Task<int> UpdateAsync(IIngradient entity);
        Task<int> DeleteAsync(IIngradient entity);
        Task<int> DeleteAsync(Guid id);
    }
}
