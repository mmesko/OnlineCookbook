using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using OnlineCookbook.Model.Common;
using OnlineCookbook.Repository.Common;
using OnlineCookbook.Service.Common;
using OnlineCookbook.Common.Filters;

namespace OnlineCookbook.Service
{
   public class PreparationStepPictureService : IPreparationStepPictureService
    {
       protected IPreparationStepPictureRepository Repository { get; private set; }

       public PreparationStepPictureService(IPreparationStepPictureRepository repository)
       {
           Repository = repository;       
       }

       public Task<List<IPreparationStepPicture>> GetAsync()
       {
           try
           {
               return Repository.GetAsync();
           }
           catch (Exception e)
           {
               throw e;
           }
             
       }


       public Task<IPreparationStepPicture> GetAsync(string id)
       {
           try
           {
               return Repository.GetAsync(id);
           }
           catch (Exception e)
           {
               throw e;
           }
       
       }

       public Task<int> InsertAsync(IPreparationStepPicture entity)
       {
           try
           {
               return Repository.InsertAsync(entity);
           }
           catch (Exception e)
           {
               throw e;
           }
       
       }

       public Task<int> UpdateAsync(IPreparationStepPicture entity)
       {
           try
           {
               return Repository.UpdateAsync(entity);
           }
           catch (Exception e)
           {
               throw e;
           }
       }


       public Task<int> DeleteAsync(IPreparationStepPicture entity)
       {
           try
           {
               return Repository.DeleteAsync(entity);
           }
           catch (Exception e)
           {
               throw e;
           }
       }

       public Task<int> DeleteAsync(string id)
       {
           try
           {
               return Repository.DeleteAsync(id);
           }
           catch (Exception e)
           {
               throw e;
           }
       }


    }
}
