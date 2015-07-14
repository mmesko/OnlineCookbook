using System.Collections.Generic;
using OnlineCookbook.Model.Common;
using System.Threading.Tasks;
using OnlineCookbook.Common.Filters;

namespace OnlineCookbook.Service.Common
{
    public interface IPreparationStepService
    {

        Task<List<IPreparationStep>> GetAsync(PreparationStepFilter filter = null);
        Task<IPreparationStep> GetAsync(string id);
        Task<List<IPreparationStep>> GetStepsAsync(string recipeId);

        Task<int> InsertAsync(IPreparationStep entity, IPreparationStepPicture picture = null);

        Task<int> UpdateAsync(IPreparationStep entity, IPreparationStepPicture picture = null);

      
        Task<int> DeleteAsync(IPreparationStep entity);
        Task<int> DeleteAsync(string id);

    }
}
