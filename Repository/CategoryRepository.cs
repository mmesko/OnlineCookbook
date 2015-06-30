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
        public IUnitOfWork UnitOfWork { get; private set; }

        public CategoryRepository(IRepository repository)
        {
            Repository = repository;
        }

        public IUnitOfWork CreateUnitOfWork()
        {
            return Repository.CreateUnitOfWork();
        }

        public virtual async Task<List<ICategory>> GetAsync(CategoryFilter filter)
        {
            try
            {
                return Mapper.Map<List<ICategory>>(
                    await Repository.WhereAsync<Category>()
                            .OrderBy(filter.SortOrder)
                            .Skip<Category>((filter.PageNumber - 1) * filter.PageSize)
                            .Take<Category>(filter.PageSize)
                            .ToListAsync<Category>()
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
                return Mapper.Map<ICategory>(
                    await Repository.SingleAsync<Category>(id));
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

        public async Task<int> DeleteAsync(ICategory entity)
        {
            try
            {
                if (entity.Abrv.ToLower() == "undef")
                {
                    throw new ArgumentException("Category\"Undefined\" cannot be deleted.");
                }
                else
                {
                    IUnitOfWork unitOfWork = Repository.CreateUnitOfWork();

                    var recipes = await Repository.WhereAsync<Recipe>()
                        .Where<Recipe>(item => item.CategoryId == entity.Id)
                        .ToListAsync();

                    var typeUndef = await Repository.WhereAsync<Category>()
                        .Where<Category>(item => item.Abrv.ToLower() == "undef")
                        .SingleAsync();

                    foreach (var recipe in recipes)
                    {
                        recipe.CategoryId = typeUndef.Id;
                        await unitOfWork.UpdateAsync<Recipe>(recipe);
                    }

                    await unitOfWork.DeleteAsync<Category>(entity.Id);

                    return await unitOfWork.CommitAsync();
                }
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
                return await DeleteAsync(Mapper.Map<ICategory>(
                    await Repository.SingleAsync<Category>(id))
                    );
            }
          
            catch (Exception e)
            {
                throw e;
            }
        }

    }
}
