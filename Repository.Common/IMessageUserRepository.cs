using System;
using System.Linq;
using System.Collections.Generic;
using OnlineCookbook.Model.Common;
using System.Threading.Tasks;

namespace OnlineCookbook.Repository.Common
{
    public interface IMessageUserRepository
    {
        Task<List<IMessageUser>> GetAsync(string sortOrder = "messageUserId", int pageNumber = 0, int pageSize = 20);
        Task<IMessageUser> GetAsync(string id);
        Task<int> InsertAsync(IMessageUser entity);
        Task<int> UpdateAsync(IMessageUser entity);
        Task<int> DeleteAsync(IMessageUser entity);
        Task<int> DeleteAsync(string id);
    }
}
