using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using OnlineCookbook.Model.Common;
using OnlineCookbook.Repository.Common;
using OnlineCookbook.Service.Common;
using OnlineCookbook.Common.Filters;

namespace OnlineCookbook.Service
{
    public class RecipeIngradientService : IRecipeIngradientService
    {

        protected IRecipeIngradientRepository Repository { get; private set; }

        public RecipeIngradientService(IRecipeIngradientRepository repository)
       {
           Repository = repository;      
       }

       //method Get

       public Task<List<IRecipeIngradient>> GetAsync(RecipeIngradientFilter filter = null)
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

       public Task<IRecipeIngradient> GetAsync(string id)
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

       public Task<int> InsertAsync(IRecipeIngradient entity)
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

       public Task<int> UpdateAsync(IRecipeIngradient entity)
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

       public Task<int> DeleteAsync(IRecipeIngradient entity)
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

       public Task<List<IRecipeIngradient>> GetRecipeIngradientAsync(string recipeId, RecipeIngradientFilter filter = null)
       {
           try
           {
               return Repository.GetRecipeIngradientAsync(recipeId, filter);
           }
           catch (Exception e)
           {
               throw e;
           }
       }
    }
}
