using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using OnlineCookbook.Model.Common;
using OnlineCookbook.Repository.Common;
using OnlineCookbook.Service.Common;
using OnlineCookbook.Common.Filters;


namespace OnlineCookbook.Service
{
    public class AlergenService : IAlergenService
    {

        private IAlergenRepository Repository { get;  set; }
       

        public AlergenService(IAlergenRepository repository)
        {
            if (repository == null)
                throw new ArgumentNullException("Repository must be != null");
 
            Repository = repository;
        }

        public async Task<List<IAlergen>> GetAsync(AlergenFilter filter)
        {
            try
            {
                return await Repository.GetAsync(filter);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<IAlergen> GetAsync(string id)
        {

            try
            {
                return await Repository.GetAsync(id);
            }

            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<List<IAlergen>> GetNameAsync(string name)
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

        public async Task<int> InsertAsync(IAlergen entity)
        {

            try
            {
                return await Repository.InsertAsync(entity);
            }

            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<int> UpdateAsync(IAlergen entity)
        {
            try
            {
                return await Repository.UpdateAsync(entity);
            }

            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<int> DeleteAsync(IAlergen entity)
        {
            try
            {
                return await Repository.DeleteAsync(entity);
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
                return await Repository.DeleteAsync(id);
            }

            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
