using System.Collections.Generic;
using OnlineCookbook.Model.Common;
using System.Threading.Tasks;

namespace OnlineCookbook.Repository.Common
{
    public interface IPreparationStepPictureRepository
    {
        Task<List<IPreparationStepPicture>> GetAsync();
        Task<IPreparationStepPicture> GetAsync(string id);

        Task<int> AddAsync(IUnitOfWork unitOfWork, IPreparationStepPicture entity);
        Task<int> InsertAsync(IPreparationStepPicture entity);

        Task<int> UpdateAsync(IUnitOfWork unitOfWork, IPreparationStepPicture entity);
        Task<int> UpdateAsync(IPreparationStepPicture entity);

        Task<int> DeleteAsync(IPreparationStepPicture entity);
        Task<int> DeleteAsync(string id);
    }
}
