using System;
using AutoMapper;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Dynamic;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using OnlineCookbook.Repository.Common;
using OnlineCookbook.DAL.Models;
using OnlineCookbook.Model.Common;
using OnlineCookbook.Model;

namespace OnlineCookbook.Repository
{
   public class RecipePictureRepository : IRecipePictureRepository
    {
        protected IRepository Repository { get; private set; }
       

        public RecipePictureRepository(IRepository repository)
        {
            Repository = repository;       
        }

        private IUnitOfWork CreateUnitOfWork()
        {
            return Repository.CreateUnitOfWork();
        }



        public virtual async Task<List<IRecipePicture>> GetAsync()
        {
            try
            {
                return Mapper.Map<List<IRecipePicture>>(
                    await Repository.WhereAsync<RecipePicture>()
                    .ToListAsync()
                    );
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public virtual async Task<IRecipePicture> GetAsync(string id)
        {
            try
            {
               

                return Mapper.Map<IRecipePicture>(await Repository.SingleAsync<RecipePicture>(id));
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        public virtual Task<int> InsertAsync(IRecipePicture entity)
        {
            try
            {
                return Repository.InsertAsync<RecipePicture>(Mapper.Map<RecipePicture>(entity));
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Task<int> AddAsync(IUnitOfWork unitOfWork, IRecipePicture entity)
        {
            try
            {
                return unitOfWork.AddAsync<RecipePicture>(
                    Mapper.Map<RecipePicture>(entity));
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public virtual async Task<int> UpdateAsync(IRecipePicture entity)
        {
            try
            {
                return await Repository.UpdateAsync<RecipePicture>(Mapper.Map<RecipePicture>(entity));
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public virtual Task<int> DeleteAsync(IRecipePicture entity)
        {
            try
            {
                return Repository.DeleteAsync<RecipePicture>(
                    Mapper.Map<RecipePicture>(entity));
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
                return Repository.DeleteAsync<RecipePicture>(id);
            }
            catch (Exception e)
            {
                throw e;
            }
        }


    }
}
