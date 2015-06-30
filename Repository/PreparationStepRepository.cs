using System;
using AutoMapper;
using System.Data.Entity;
using System.Linq;
using System.Linq.Dynamic;
using System.Collections.Generic;
using System.Threading.Tasks;
using OnlineCookbook.Repository.Common;
using OnlineCookbook.DAL.Models;
using OnlineCookbook.Model.Common;
using OnlineCookbook.Common.Filters;

namespace OnlineCookbook.Repository
{
    public class PreparationStepRepository : IPreparationStepRepository
    {
       
         protected IRepository Repository { get; private set; }

         public PreparationStepRepository(IRepository repository)
         {
             Repository = repository;
         }


         public virtual async Task<List<IPreparationStep>> GetAsync(PreparationStepFilter filter = null)
         {
             try
             {
                 if (filter != null)
                 {
                     return Mapper.Map<List<IPreparationStep>>(
                         await Repository.WhereAsync<PreparationStep>()
                         .OrderBy(filter.SortOrder)
                         .Skip<PreparationStep>((filter.PageNumber - 1) * filter.PageSize)
                         .Take<PreparationStep>(filter.PageSize)
                         .Include(item => item.PreparationStepPictures)
                         .ToListAsync<PreparationStep>()
                         );
                 }
                 else // return all
                 {
                     return Mapper.Map<List<IPreparationStep>>(
                         await Repository.WhereAsync<PreparationStep>()
                         .Include(item => item.PreparationStepPictures)
                         .ToListAsync()
                         );
                 }
             }
             catch (Exception e)
             {
                 throw e;
             }
         }

         public virtual async Task<IPreparationStep> GetAsync(string id)
         {
             try
             {
                 return Mapper.Map<IPreparationStep>(
                     await Repository.WhereAsync<PreparationStep>()
                     .Where(item => item.Id == id)
                     .Include(item => item.PreparationStepPictures)
                     .SingleAsync()
                     );
             }
             catch (Exception e)
             {
                 throw e;
             }
         }

         public async Task<List<IPreparationStep>> GetStepsAsync(string recipeId)
         {
             try
             {
                 return Mapper.Map<List<IPreparationStep>>(
                     await Repository.WhereAsync<PreparationStep>()
                     .Where<PreparationStep>(item => item.RecipeId == recipeId)
                     .OrderBy(item => item.StepNumber)
                     .Include(item => item.PreparationStepPictures)
                     .ToListAsync<PreparationStep>()
                     );
             }
             catch (Exception e)
             {
                 throw e;
             }
         }
         public async Task<int> AddAsync(IUnitOfWork unitOfWork, IPreparationStep entity)
         {
             try
             {
                 var numberOfSteps = (short)(await GetStepsAsync(entity.RecipeId)).Count;
                 if (entity.StepNumber < 1 || entity.StepNumber > numberOfSteps)
                 {
                     throw new ArgumentException("Invalid StepNumber.");
                 }

                 var stepEntity = Mapper.Map<PreparationStep>(entity);

                 var stepNumber = stepEntity.StepNumber;
                 stepEntity.StepNumber = numberOfSteps;
                 stepEntity.StepNumber++;

                 // insert as last step
                 await unitOfWork.AddAsync<PreparationStep>(stepEntity);

                 // update step numbers
                 stepEntity.StepNumber = stepNumber;
                 return await UpdateAsync(unitOfWork, stepEntity);
             }
             catch (Exception e)
             {
                 throw e;
             }
         }

         public virtual async Task<int> InsertAsync(IPreparationStep entity)
         {
             try
             {
                 IUnitOfWork unitOfWork = Repository.CreateUnitOfWork();
                 await AddAsync(unitOfWork, entity);
                 return await unitOfWork.CommitAsync();
             }
             catch (Exception e)
             {
                 throw e;
             }
         }

        //add pictures
         public virtual async Task<int> AddAsync(IUnitOfWork unitOfWork, List<IPreparationStep> entities,
            List<IPreparationStepPicture> pictures = null)
         {
             try
             {
                 var result = 0;
                 entities = entities.OrderBy(item => item.StepNumber).ToList();

                 for (int i = 0; i < entities.Count; i++)
                 {
                     result += await this.AddAsync(unitOfWork, entities.ElementAt(i));
                 }

                 if (pictures != null)
                 {
                     foreach (var picture in pictures)
                     {
                         result += await unitOfWork.AddAsync<PreparationStepPicture>(
                             Mapper.Map<PreparationStepPicture>(picture));
                     }
                 }

                 return result;
             }
             catch (Exception e)
             {
                 throw e;
             }
         }

         private async Task<int> UpdateAsync(IUnitOfWork unitOfWork, PreparationStep entity)
         {
             try
             {
                 var steps = await Repository.WhereAsync<PreparationStep>()
                     .Where(item => item.RecipeId == entity.RecipeId)
                     .OrderBy(item => item.StepNumber)
                     .ToListAsync();

                 var numberOfSteps = steps.Count;
                 var oldStepNumber = (await Repository.SingleAsync<PreparationStep>(entity.Id)).StepNumber;
                 var newStepNumber = entity.StepNumber;

                 if (oldStepNumber == newStepNumber)
                 {
                     return await unitOfWork.UpdateAsync<PreparationStep>(entity);
                 }
                 else
                 {
                     var tempStepNumber = (short)(numberOfSteps + 1);
                     entity.StepNumber = tempStepNumber;
                     await unitOfWork.UpdateAsync<PreparationStep>(entity);

                     if (newStepNumber < oldStepNumber) // update 5 to 2
                     {
                         for (int i = newStepNumber - 1; i < oldStepNumber - 1; i++)
                         {
                             steps[i].StepNumber++;
                             await unitOfWork.UpdateAsync<PreparationStep>(steps[i]);
                         }
                     }
                     else // update 2 to 5
                     {
                         for (int i = oldStepNumber; i < newStepNumber; i++)
                         {
                             steps[i].StepNumber--;
                             await unitOfWork.UpdateAsync<PreparationStep>(steps[i]);
                         }
                     }
                     entity.StepNumber = newStepNumber;
                     return await unitOfWork.UpdateAsync<PreparationStep>(entity);
                 }
             }
             catch (Exception e)
             {
                 throw e;
             }
         }

         public async Task<int> UpdateAsync(IPreparationStep entity)
         {
             try
             {
                 IUnitOfWork unitOfWork = Repository.CreateUnitOfWork();
                 await UpdateAsync(unitOfWork, entity);
                 return await unitOfWork.CommitAsync();
             }
             catch (Exception e)
             {
                 throw e;
             }
         }

         public Task<int> UpdateAsync(IUnitOfWork unitOfWork, IPreparationStep entity)
         {
             try
             {
                 return UpdateAsync(unitOfWork, Mapper.Map<PreparationStep>(entity));
             }
             catch (Exception e)
             {
                 throw e;
             }
         }

         public async Task<int> DeleteAsync(IUnitOfWork unitOfWork, IPreparationStep entity)
         {
             try
             {
                 var stepEntity = Mapper.Map<PreparationStep>(entity);

                 var numberOfSteps = (await Repository.WhereAsync<PreparationStep>()
                     .Where(item => item.RecipeId == entity.RecipeId)
                     .ToListAsync())
                     .Count;

                 if (entity.StepNumber < numberOfSteps)
                 {
                     // move to last place
                     stepEntity.StepNumber = (short)numberOfSteps;
                     await UpdateAsync(unitOfWork, stepEntity);
                 }

                 return await unitOfWork.DeleteAsync<PreparationStep>(stepEntity);
             }
             catch (Exception e)
             {
                 throw e;
             }
         }

         public async Task<int> DeleteAsync(IUnitOfWork unitOfWork, string recipeId)
         {
             try
             {
                 var result = 0;

                 var steps = await Repository.WhereAsync<PreparationStep>()
                     .Where<PreparationStep>(item => item.RecipeId == recipeId)
                     .Include(item => item.PreparationStepPictures)
                     .ToListAsync<PreparationStep>();

                 foreach (var step in steps)
                 {
                     foreach (var picture in step.PreparationStepPictures)
                     {
                         result += await unitOfWork.DeleteAsync<PreparationStepPicture>(picture);
                     }
                     result += await unitOfWork.DeleteAsync<PreparationStep>(step);
                 }
                 return result;
             }
             catch (Exception e)
             {
                 throw e;
             }
         }

         public async Task<int> DeleteAsync(IPreparationStep entity)
         {
             try
             {
                 var unitOfWork = Repository.CreateUnitOfWork();

                 var pictures = await Repository.WhereAsync<PreparationStepPicture>()
                     .Where(item => item.PreparationStepId == entity.Id)
                     .ToListAsync();

                 if (pictures.Count > 0)
                 {
                     foreach (var picture in pictures)
                     {
                         await unitOfWork.DeleteAsync<PreparationStepPicture>(picture);
                     }
                 }
                 await this.DeleteAsync(entity);

                 return await unitOfWork.CommitAsync();
             }
             catch (Exception e)
             {
                 throw e;
             }
         }

         public async virtual Task<int> DeleteAsync(string id)
         {
             try
             {
                 return await DeleteAsync(Mapper.Map<IPreparationStep>(
                     await Repository.SingleAsync<PreparationStep>(id)));
             }
             catch (Exception e)
             {
                 throw e;
             }
         }

         public Task<IUnitOfWork> CreateUnitOfWork()
         {
             try
             {
                 return Task.FromResult(Repository.CreateUnitOfWork());
             }
             catch (Exception e)
             {
                 throw e;
             }
         }
    }
}
