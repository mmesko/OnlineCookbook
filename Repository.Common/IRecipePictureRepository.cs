using System;
using System.Linq;
using System.Collections.Generic;
using OnlineCookbook.Model.Common;
using System.Threading.Tasks;

namespace OnlineCookbook.Repository.Common
{
    public interface IRecipePictureRepository
    {
         Task<List<IRecipePicture>> GetAsync(string sortOrder = "recipePictureId", int pageNumber = 0, int pageSize = 20);
         Task<IRecipePicture> GetAsync(Guid id);
         Task<int> InsertAsync(IRecipePicture entity);
         Task<int> UpdateAsync(IRecipePicture entity);
         Task<int> DeleteAsync(IRecipePicture entity);
         Task<int> DeleteAsync(Guid id);
    }
}
