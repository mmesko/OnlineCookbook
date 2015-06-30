using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using OnlineCookbook.Model.Common;
using OnlineCookbook.Repository.Common;
using OnlineCookbook.DAL.Models;
using AutoMapper;

namespace OnlineCookbook.Repository
{
   public class PreparationStepPictureRepository : IPreparationStepPictureRepository
    {

       protected IRepository Repository { get; private set; }

       public PreparationStepPictureRepository(IRepository repository)
        {
            Repository = repository;
        }

       public virtual async Task<List<IPreparationStepPicture>> GetAsync()
       {
           try
           {
               return Mapper.Map<List<IPreparationStepPicture>>(
                   await Repository.WhereAsync<PreparationStepPicture>()
                   .ToListAsync()
                   );
           }
           catch (Exception e)
           {
               throw e;
           }
       }

       public virtual async Task<IPreparationStepPicture> GetAsync(string id)
       {
           try
           {
               return Mapper.Map<IPreparationStepPicture>(
                   await Repository.SingleAsync<PreparationStepPicture>(id));
           }
           catch (Exception e)
           {
               throw e;
           }
       }

       public virtual Task<int> AddAsync(IUnitOfWork unitOfWork, IPreparationStepPicture entity)
       {
           try
           {
               return unitOfWork.AddAsync<PreparationStepPicture>(
                   Mapper.Map<PreparationStepPicture>(entity));
           }
           catch (Exception e)
           {
               throw e;
           }
       }
    
       public virtual Task<int> InsertAsync(IPreparationStepPicture entity)
       {
           try
           {
               return Repository.InsertAsync<PreparationStepPicture>(
                   Mapper.Map<PreparationStepPicture>(entity));
           }
           catch (Exception e)
           {
               throw e;
           }
       }

       public virtual Task<int> UpdateAsync(IUnitOfWork unitOfWork, IPreparationStepPicture entity)
       {
           try
           {
               return unitOfWork.UpdateAsync<PreparationStepPicture>(
                   Mapper.Map<PreparationStepPicture>(entity));
           }
           catch (Exception e)
           {
               throw e;
           }
       }

      
       public virtual Task<int> UpdateAsync(IPreparationStepPicture entity)
       {
           try
           {
               return Repository.UpdateAsync<PreparationStepPicture>(
                   Mapper.Map<PreparationStepPicture>(entity));
           }
           catch (Exception e)
           {
               throw e;
           }
       }

       public virtual Task<int> DeleteAsync(IPreparationStepPicture entity)
       {
           try
           {
               return Repository.DeleteAsync<PreparationStepPicture>(
                   Mapper.Map<PreparationStepPicture>(entity));
           }
           catch (Exception e)
           {
               throw e;
           }
       }

       public virtual Task<int> DeleteAsync(string id)
       {
           try
           {
               return Repository.DeleteAsync<PreparationStepPicture>(id);
           }
           catch (Exception e)
           {
               throw e;
           }
       }

    }
}
