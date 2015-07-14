using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using OnlineCookbook.Model.Common;
using OnlineCookbook.Repository.Common;
using OnlineCookbook.Service.Common;
using OnlineCookbook.Common.Filters;

namespace OnlineCookbook.Service
{
    public class IngradientService : IIngradientService
    {
        
        protected IIngradientRepository Repository { get; private set; }

        public IngradientService(IIngradientRepository repository)
        {
            Repository = repository;
        }


        public Task<List<IIngradient>> GetAsync(IngradientFilter filter)
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

        public Task<IIngradient> GetAsync(string id)
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

        public async Task<List<IIngradient>> GetNameAsync(string name)
        {
            try
            {
                return await Repository.GetNameAsync(name);
            }

            catch (Exception e)
            {
                throw e;
            }
        }


        public Task<int> InsertAsync(IIngradient entity)
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

        public Task<int> UpdateAsync(IIngradient entity)
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

        public Task<int> DeleteAsync(IIngradient entity)
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
