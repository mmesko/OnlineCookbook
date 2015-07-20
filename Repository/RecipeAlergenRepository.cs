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
using OnlineCookbook.Model;
using OnlineCookbook.Common.Filters;

namespace OnlineCookbook.Repository
{
   public class RecipeAlergenRepository : IRecipeAlergenRepository
    {   
       //Ctor is Generic Repository
       protected IRepository Repository { get; private set; }

       //DI concept; constructor
       
        public RecipeAlergenRepository(IRepository repository)
        {
            Repository = repository;
        }

        public virtual async Task<List<IRecipeAlergen>> GetAsync(RecipeAlergenFilter filter = null)
        {
            try
            {
                if (filter == null)
                    filter = new RecipeAlergenFilter(1, 5);

                return Mapper.Map<List<IRecipeAlergen>>(
                    await Repository.WhereAsync<RecipeAlergen>()
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

        public virtual async Task<IRecipeAlergen> GetAsync(string id)
        {
            try
            {
                return Mapper.Map<IRecipeAlergen>(await Repository.SingleAsync<RecipeAlergen>(id));
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        public virtual Task<int> InsertAsync(IRecipeAlergen entity)
        {
            try
            {
                return Repository.InsertAsync<RecipeAlergen>(Mapper.Map<RecipeAlergen>(entity));
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public virtual Task<int> UpdateAsync(IRecipeAlergen entity)
        {
            try
            {
                return Repository.UpdateAsync<RecipeAlergen>(Mapper.Map<RecipeAlergen>(entity));
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Task<int> DeleteAsync(IRecipeAlergen entity)
        {
            try
            {
                return Repository.DeleteAsync<RecipeAlergen>(Mapper.Map<RecipeAlergen>(entity));
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
                return Repository.DeleteAsync<RecipeAlergen>(id);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public virtual async Task<List<IRecipe>> GetRecipeAlergenAsync(string recipeId, string alergenUnit)
        { 
            try
            {

                // get entity with RecipeId of the Recipe we are looking for
                var recipe = await Repository.WhereAsync<RecipeAlergen>()
                      //all must be in same table
                      .Where(item => item.RecipeId == recipeId && item.AlergenUnit == alergenUnit)
                      .Include(item=>item.Recipe)
                      .ToListAsync();

                //return List of recipes
                return Mapper.Map<List<IRecipe>>(recipe);
  
            }
        
           catch(Exception e)
            {
           
              throw e;
           }
        
        
        }


        
 
    }
}
