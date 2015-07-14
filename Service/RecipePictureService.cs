using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OnlineCookbook.Repository.Common;
using OnlineCookbook.Model.Common;
using OnlineCookbook.Service.Common;

namespace OnlineCookbook.Service
{
    public class RecipePictureService : IRecipePictureService
    {

        protected IRecipePictureRepository Repository { get; private set; }
        RecipePictureService(IRecipePictureRepository repository)
        {
            Repository = repository;
        }

        public Task<List<IRecipePicture>> GetAsync()
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

        public Task<IRecipePicture> GetAsync(string id)
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

        public Task<int> InsertAsync(IRecipePicture entity)
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

        public Task<int> UpdateAsync(IRecipePicture entity)
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

        public Task<int> DeleteAsync(IRecipePicture entity)
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
