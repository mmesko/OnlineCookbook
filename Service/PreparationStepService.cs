using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using OnlineCookbook.Model.Common;
using OnlineCookbook.Repository.Common;
using OnlineCookbook.Service.Common;
using OnlineCookbook.Common.Filters;

namespace OnlineCookbook.Service
{
   public class PreparationStepService : IPreparationStepService
    {

       protected IPreparationStepRepository Repository { get; private set; }
       protected IPreparationStepPictureRepository PictureRepository { get; private set; }

       public PreparationStepService(IPreparationStepRepository repository, 
           IPreparationStepPictureRepository pictureRepository)
       {
           Repository = repository;
           PictureRepository = pictureRepository;
       }


       public Task<List<IPreparationStep>> GetAsync(PreparationStepFilter filter = null)
       {
           try
           {
               return Repository.GetAsync(filter);
           }
           catch (Exception e)
           {
               throw e;
           }
       
       }

       public Task<IPreparationStep> GetAsync(string id)
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

       public Task<List<IPreparationStep>> GetStepsAsync(string recipeId)
       {
           try
           {
               return Repository.GetStepsAsync(recipeId);
           }
           catch (Exception e)
           {
               throw e;
           }
       
       }

       public async Task<int> InsertAsync(IPreparationStep entity, IPreparationStepPicture picture = null)
       {
           try
           {   
               var unitOfWork = await Repository.CreateUnitOfWork();

               if (picture != null)
               {
                   await Repository.AddAsync(unitOfWork, entity);
                   await PictureRepository.AddAsync(unitOfWork, picture);
                   return await unitOfWork.CommitAsync();

               }
               else
               {
                   return await Repository.InsertAsync(entity);
               
               }
            
           }
           catch (Exception e)
           {
               throw e;
           }
       
       }

      public async Task<int> UpdateAsync(IPreparationStep entity, IPreparationStepPicture picture = null)
       {

           try
           {
               var unitOfWork = await Repository.CreateUnitOfWork();

               if (picture != null)
               {
                   await Repository.UpdateAsync(unitOfWork, entity);
                   await PictureRepository.UpdateAsync(unitOfWork, picture);

                   return await unitOfWork.CommitAsync();

               }
               else 
               {
                   return await Repository.InsertAsync(entity);
               }

           }
           catch (Exception e)
           {
               throw e;
           }       
       
       }


      public Task<int> DeleteAsync(IPreparationStep entity)
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
