using System;
using System.Linq;
using System.Collections.Generic;
using OnlineCookbook.Model.Common;
using System.Threading.Tasks;

namespace OnlineCookbook.Repository.Common
{
   public interface IPreparationStepRepository
    {
       Task<List<IPreparationStep>> GetAsync(string sortOrder = "preparationStepId", int pageNumber = 0, int pageSize = 20);
       Task<IPreparationStep> GetAsync(Guid id);
       Task<int> InsertAsync(IPreparationStep entity);
       Task<int> UpdateAsync(IPreparationStep entity);
       Task<int> DeleteAsync(IPreparationStep entity);
       Task<int> DeleteAsync(Guid id);
    }
}
