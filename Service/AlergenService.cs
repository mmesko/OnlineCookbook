using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineCookbook.Model.Common;
using OnlineCookbook.Repository.Common;
using OnlineCookbook.Service.Common;


namespace OnlineCookbook.Service
{
    public class AlergenService : IAlergenService
    {

        protected IAlergenRepository Repository { get; private set; }

        public AlergenService(IAlergenRepository repository)
        {
            Repository = repository;
        }


        public Task<List<IAlergen>> GetAsync(string sortOrder = "alergenId", int pageNumber = 0, int pageSize = 20)
        {
            try
            {
                return Repository.GetAsync(sortOrder, pageNumber,pageSize);
            }

            catch (Exception e)
            {
                throw e;
            }
        }

        public Task<IAlergen> GetAsync(Guid id)
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

        public Task<int> InsertAsync(IAlergen entity)
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

        public Task<int> UpdateAsync(IAlergen entity)
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

        public Task<int> DeleteAsync(IAlergen entity)
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

        public Task<int> DeleteAsync(Guid id)
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
