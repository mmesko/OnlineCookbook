using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using OnlineCookbook.Model.Common;
using OnlineCookbook.Repository.Common;
using OnlineCookbook.Service.Common;
using OnlineCookbook.Common.Filters;

namespace OnlineCookbook.Service
{
   public class RecipeService : IRecipeService
    {
       protected IRecipeRepository Repository { get; private set; }
       protected IRecipePictureRepository PictureRepository { get; private set; }
       protected IPreparationStepRepository StepRepository { get; private set; }
       

       public RecipeService(IRecipeRepository repository, IRecipePictureRepository pictureRepository,
           IPreparationStepRepository stepRepository)
       {
           Repository = repository;
           PictureRepository = pictureRepository;
           StepRepository = stepRepository;
       
       }

       public Task<List<IRecipe>> GetAsync(RecipeFilter filter = null)
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

       public Task<IRecipe> GetAsync(string id)
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


       public Task<List<IRecipe>> GetByNameAsync(string name)
       {

           try
           {
               return Repository.GetByNameAsync(name);
           }

           catch (Exception e)
           {
               throw e;
           }
       
       
       }


       public Task<List<IRecipe>> GetByCategoryAsync(string categoryId, RecipeFilter filter = null)
       {

           try
           {
               return Repository.GetByCategoryAsync(categoryId, filter);
           }
           catch (Exception e)
           {
               throw e;
           }
       
       }

       public async Task<int> InsertAsync(IRecipe entity, IRecipePicture picture = null,
            List<IPreparationStep> steps = null, List<IPreparationStepPicture> stepPictures = null)
       {

           try
           {

               if (steps == null && stepPictures != null)
               {
                   throw new ArgumentNullException("Null steps, but try to add pictures!");
               }

               var unitOfWork = await Repository.CreateUnitOfWork();
               await Repository.AddAsync(unitOfWork, entity);

               if (picture != null)
               {
                   await PictureRepository.AddAsync(unitOfWork, picture);
               }

               if (steps != null)
               {

                   await StepRepository.AddAsync(unitOfWork, steps, stepPictures);
               }

               return await unitOfWork.CommitAsync();

           }
           catch (Exception e)
           {
               throw e;

           }
       }

           public Task<int> UpdateAsync(IRecipe entity)
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

           public async Task<int> DeleteAsync(IRecipe entity)
           {
               try 
               {
                   var unitOfWork = await Repository.CreateUnitOfWork();
                   await StepRepository.DeleteAsync(unitOfWork, entity.Id);
                   await Repository.DeleteAsync(unitOfWork, entity);

                   return await unitOfWork.CommitAsync();
               }
               catch (Exception e)
               {
                   throw e;
               }          
           }

           public async Task<int> DeleteAsync(string id)
           {
               try
               {
                   return await this.DeleteAsync(await this.GetAsync(id)); //jer nece uzeti Repository pa trebam this
               }
               catch (Exception e)
               {
                   throw e;
               }
           }
    }
}
