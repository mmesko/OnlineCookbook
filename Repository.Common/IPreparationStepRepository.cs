using System.Collections.Generic;
using OnlineCookbook.Model.Common;
using System.Threading.Tasks;
using OnlineCookbook.Common.Filters;

namespace OnlineCookbook.Repository.Common
{
   public interface IPreparationStepRepository
    {
       Task<List<IPreparationStep>> GetAsync(PreparationStepFilter filter = null);
       Task<IPreparationStep> GetAsync(string id);
       Task<List<IPreparationStep>> GetStepsAsync(string recipeId);
       Task<int> InsertAsync(IPreparationStep entity);
       Task<int> AddAsync(IUnitOfWork unitOfWork, IPreparationStep entity);
       Task<int> AddAsync(IUnitOfWork unitOfWork, List<IPreparationStep> entities, List<IPreparationStepPicture> pictures = null);

       Task<int> UpdateAsync(IUnitOfWork unitOfWork, IPreparationStep entity);
       Task<int> UpdateAsync(IPreparationStep entity);

       Task<int> DeleteAsync(IUnitOfWork unitOfWork, IPreparationStep entity);
       Task<int> DeleteAsync(IUnitOfWork unitOfWork, string recipeId);
       Task<int> DeleteAsync(IPreparationStep entity);
       Task<int> DeleteAsync(string id);
       Task<IUnitOfWork> CreateUnitOfWork();
    }
}
