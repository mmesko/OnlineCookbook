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
using OnlineCookbook.Common.Filters;

namespace OnlineCookbook.Repository
{
    public class CategoryRepository : ICategoryRepository
    {

        protected IRepository Repository { get; private set; }


        public CategoryRepository(IRepository repository)
        {

            Repository = repository;       
        }


        public virtual async Task<List<ICategory>> GetAsync(CategoryFilter filter)
        {
            try
            {
                if (filter == null)
                    filter = new CategoryFilter(1, 5);


                return Mapper.Map<List<ICategory>>(
                    await Repository.WhereAsync<Category>()
                            .OrderBy(a => a.CategoryName)
                            .Skip((filter.PageNumber * filter.PageSize) - filter.PageSize)
                            .Take(filter.PageSize).ToListAsync()
                    );
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public virtual async Task<ICategory> GetAsync(string id)
        {
            try 
            {
                return Mapper.Map<ICategory>(await Repository.SingleAsync<Category>(id));           
            }
            catch (Exception e)
            {
                throw e;
            }        
        }

        public virtual async Task<List<ICategory>> GetNameAsync(string name)
        {
            try
            {
                return Mapper.Map<List<ICategory>>(
                    await Repository.WhereAsync<Category>()
                            .Where(item => item.CategoryName.Contains(name))
                            .ToListAsync<Category>()
                    );
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        public virtual Task<int> InsertAsync(ICategory entity)
        {
            try
            {
                return Repository.InsertAsync<Category>(Mapper.Map<Category>(entity));
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public virtual Task<int> UpdateAsync(ICategory entity)
        {
            try
            {
                return Repository.UpdateAsync<Category>(Mapper.Map<Category>(entity));
            }

            catch (Exception e)
            {
                throw e;
            }     
        }

        public virtual Task<int> DeleteAsync(ICategory entity)
        {
            try
            {
                return Repository.DeleteAsync<Category>
                    (Mapper.Map<Category>(entity));
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
                return Repository.DeleteAsync<Category>(id);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

    }
}
