using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using OnlineCookbook.Model.Common;
using OnlineCookbook.Repository.Common;
using OnlineCookbook.Service.Common;
using OnlineCookbook.Common.Filters;


namespace OnlineCookbook.Service
{
   public class RecipeAlergenService : IRecipeAlergenService
    {

       protected IRecipeAlergenRepository Repository { get; private set; }

       public RecipeAlergenService(IRecipeAlergenRepository repository)
       {
           Repository = repository;      
       }

       //method Get

       public Task<List<IRecipeAlergen>> GetAsync(RecipeAlergenFilter filter = null)
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

       public Task<IRecipeAlergen> GetAsync(string id)
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

       public Task<int> InsertAsync(IRecipeAlergen entity)
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

       public Task<int> UpdateAsync(IRecipeAlergen entity)
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

       public Task<int> DeleteAsync(IRecipeAlergen entity)
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

       public Task<List<IRecipe>> GetRecipeAlergenAsync(string recipeId, string alergenUnit)
       {
           try
           {
               return Repository.GetRecipeAlergenAsync(recipeId, alergenUnit);
           }
           catch (Exception e)
           {
               throw e;
           }
       }

    }
}
