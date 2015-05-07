using System;
using System.Linq;
using System.Collections.Generic;
using OnlineCookbook.Model.Common;
using System.Threading.Tasks;

namespace OnlineCookbook.Repository.Common
{
   public interface IMessageRepository
    {
       Task<List<IMessage>> GetAsync(string sortOrder = "messageId", int pageNumber = 0, int pageSize = 20);
       Task<IMessage> GetAsync(Guid id);
       Task<int> InsertAsync(IMessage entity);
       Task<int> UpdateAsync(IMessage entity);
       Task<int> DeleteAsync(IMessage entity);
        Task<int> DeleteAsync(Guid id);
    }
}
