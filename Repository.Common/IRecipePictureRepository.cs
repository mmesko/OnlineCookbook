using System;
using System.Linq;
using System.Collections.Generic;
using OnlineCookbook.Model.Common;
using System.Threading.Tasks;

namespace OnlineCookbook.Repository.Common
{
    public interface IRecipePictureRepository
    {
         Task<List<IRecipePicture>> GetAsync();
         Task<IRecipePicture> GetAsync(string id);
         Task<int> InsertAsync(IRecipePicture entity);
         Task<int> UpdateAsync(IRecipePicture entity);
         Task<int> DeleteAsync(IRecipePicture entity);
         Task<int> DeleteAsync(string id);
         Task<int> AddAsync(IUnitOfWork unitOfWork, IRecipePicture entity);
    }
}
