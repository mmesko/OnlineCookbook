using OnlineCookbook.Common.Filters;
using OnlineCookbook.Model.Common;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineCookbook.Repository.Common
{
   public interface IRecipePictureRepository
    {

        Task<IRecipePicture> GetAsync(string id);
        Task<List<IRecipePicture>> GetRangeAsync(GenericFilter filter);
        Task<List<IRecipePicture>> GetRangeAsync(string recipeId, GenericFilter filter);
        Task<int> InsertAsync(IRecipePicture entity);
        Task<int> UpdateAsync(IRecipePicture entity);
        Task<int> DeleteAsync(IRecipePicture etity);
    }
}
