using System;
using System.Linq;
using System.Collections.Generic;
using OnlineCookbook.Model.Common;
using System.Threading.Tasks;

namespace OnlineCookbook.Repository.Common
{
    public interface IPreparationStepPictureRepository
    {
        Task<List<IPreparationStepPicture>> GetAsync(string sortOrder = "preparationStepPictureId", int pageNumber = 0, int pageSize = 20);
        Task<IPreparationStepPicture> GetAsync(Guid id);
        Task<int> InsertAsync(IPreparationStepPicture entity);
        Task<int> UpdateAsync(IPreparationStepPicture entity);
        Task<int> DeleteAsync(IPreparationStepPicture entity);
        Task<int> DeleteAsync(Guid id);
    }
}
