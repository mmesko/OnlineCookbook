using System.Collections.Generic;
using System.Threading.Tasks;
using OnlineCookbook.Model.Common;
using OnlineCookbook.Common.Filters;


namespace OnlineCookbook.Service.Common
{
   public interface IPreparationStepPictureService
    {

        Task<List<IPreparationStepPicture>> GetAsync();
        Task<IPreparationStepPicture> GetAsync(string id);
        Task<int> InsertAsync(IPreparationStepPicture entity);
        Task<int> UpdateAsync(IPreparationStepPicture entity);
        Task<int> DeleteAsync(IPreparationStepPicture entity);
        Task<int> DeleteAsync(string id);

    }
}
