using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using OnlineCookbook.Model.Common;
using OnlineCookbook.Repository.Common;
using OnlineCookbook.Service.Common;
using OnlineCookbook.Common.Filters;


namespace OnlineCookbook.Service
{
     public class CategoryService : ICategoryService
    {


         #region Properties

        protected ICategoryRepository Repository { get; private set; }

        #endregion Properties

        #region Constructors

        public CategoryService(ICategoryRepository repository)
        {
            Repository = repository;
        }

        #endregion Constructors

        #region Methods

        public Task<List<ICategory>> GetAsync(CategoryFilter filter)
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

        public Task<ICategory> GetAsync(string id)
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

        public Task<int> InsertAsync(ICategory entity)
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

        public Task<int> UpdateAsync(ICategory entity)
        {
            try
            {
                return Repository.UpdateAsync(entity);
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }
        }

        public Task<int> DeleteAsync(ICategory entity)
        {
            try
            {
                return Repository.DeleteAsync(entity);
            }
            catch (ArgumentException e)
            {
                throw e;
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

        #endregion Methods


    }
}
