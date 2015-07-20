using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Dynamic;
using System.Threading.Tasks;

using OnlineCookbook.Repository.Common;
using OnlineCookbook.DAL.Models;
using OnlineCookbook.Model.Common;
using OnlineCookbook.Common.Filters;

namespace OnlineCookbook.Repository
{
   public class RecipeIngradientRepository : IRecipeIngradientRepository
    {
         protected IRepository Repository { get; private set; }

        public RecipeIngradientRepository(IRepository repository)
        {
            Repository = repository;
        }

        public virtual async Task<List<IRecipeIngradient>> GetAsync(RecipeIngradientFilter filter = null)
        {


            try
            {
                if (filter == null)
                    filter = new RecipeIngradientFilter(1, 5);


                return Mapper.Map<List<IRecipeIngradient>>(
                    await Repository.WhereAsync<RecipeIngradient>()
                            .Skip((filter.PageNumber * filter.PageSize) - filter.PageSize)
                            .Take(filter.PageSize)
                            .ToListAsync()
                    );
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        public virtual async Task<IRecipeIngradient> GetAsync(string id)
        {
            try
            {
                return Mapper.Map<IRecipeIngradient>(
                    await Repository.SingleAsync<RecipeIngradient>(id)
                    );
            }
            catch (Exception e)
            {
                throw e;
            }

            
        }

        public virtual  Task<int> InsertAsync(IRecipeIngradient entity)
        {
            try
            {
                return Repository.InsertAsync<RecipeIngradient>(Mapper.Map<RecipeIngradient>(entity));

            }
            catch (Exception e)
            {
                throw e;
            }
        
        }

        public virtual Task<int> UpdateAsync(IRecipeIngradient entity)
        {
            try
            {
                return Repository.UpdateAsync<RecipeIngradient>(Mapper.Map<RecipeIngradient>(entity));
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Task<int> DeleteAsync(IRecipeIngradient entity)
        {
            try
            {
                return Repository.DeleteAsync<RecipeIngradient>(Mapper.Map<RecipeIngradient>(entity));
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
                return Repository.DeleteAsync<RecipeIngradient>(id);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public virtual async Task<List<IRecipeIngradient>> GetRecipeIngradientAsync(string recipeId, RecipeIngradientFilter filter = null)
        {
            try
            {
                if (filter != null)
                {
                    return Mapper.Map<List<IRecipeIngradient>>(
                           await Repository.WhereAsync<RecipeIngradient>()
                           .Where(item => item.RecipeId == recipeId)
                           .Skip((filter.PageNumber * filter.PageSize) - filter.PageSize)
                           .Take(filter.PageSize)
                           .Include(item => item.Ingradient)
                           .ToListAsync()


                        );
                }
                else
                {   //return all
                    return Mapper.Map<List<IRecipeIngradient>>(
                          await Repository.WhereAsync<RecipeIngradient>()
                          .Where(item => item.RecipeId == recipeId)
                          .Include(item => item.Ingradient)
                          .ToListAsync<RecipeIngradient>()
                          );
                }
            }

            catch (Exception e)
            {

                throw e;
            }
        }

             
    }
}
