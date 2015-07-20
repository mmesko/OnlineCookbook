using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineCookbook.Common.Filters;
using OnlineCookbook.Model.Common;
using OnlineCookbook.Repository.Common;
using OnlineCookbook.Service.Common;

namespace OnlineCookbook.Service
{
    public class FavouriteService : IFavouriteService
    {
        private IFavouriteRepository Repository { get; set; }

         public FavouriteService(IFavouriteRepository repository)
        {
            if (repository == null)
                throw new ArgumentNullException("Repository must be != null");
 
            Repository = repository;
        }

        public async Task<List<IFavourite>> GetAsync(string recipeId, FavouriteFilter filter = null)
        {
            try
            {
                return await Repository.GetAsync(recipeId, filter);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<IFavourite> GetAsync(string id)
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

        public async Task<List<IFavourite>> GetNameAsync(string name)
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

        public async Task<int> InsertAsync(IFavourite entity)
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

        public async Task<int> UpdateAsync(IFavourite entity)
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

        public async Task<int> DeleteAsync(IFavourite entity)
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
