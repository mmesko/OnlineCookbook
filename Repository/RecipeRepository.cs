using System;
using AutoMapper;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using OnlineCookbook.Repository.Common;
using OnlineCookbook.DAL.Models;
using OnlineCookbook.Model.Common;
using OnlineCookbook.Model;


namespace OnlineCookbook.Repository
{
    public class RecipeRepository : IRecipeRepository
    {
        
        protected IRepository Repository { get; private set; }
       

        public RecipeRepository(IRepository repository)
        {
            Repository = repository;       
        }

        private IUnitOfWork CreateUnitOfWork()
        {
            return Repository.CreateUnitOfWork();
        }

        
        public virtual async Task<List<IRecipe>> GetAsync(string sortOrder = "recipeId", int pageNumber = 1, int pageSize = 20)
        {
            try
            {
                //DAL list
                List<Recipe> page; //return page
                pageSize = (pageSize > 20) ? 20 : pageSize;

                switch (sortOrder)
                {
                    case "recipeId":
                        page = await Repository.WhereAsync<Recipe>()
                            .OrderBy(item => item.Id)
                            .Skip<Recipe>((pageNumber - 1) * pageSize)
                            .Take<Recipe>(pageSize) //whole page
                            .ToListAsync<Recipe>();
                        break;                 
                    default:
                        throw new ArgumentException("Wrong sorting!");
                }
             return new List<IRecipe>(Mapper.Map<List<RecipePOCO>>(page));//mapping from model to dal 
           }
            catch (Exception e)
            {
                throw e;
            }       
        }


        public virtual async Task<IRecipe> GetAsync(int id)
        {
            try 
            {
                return Mapper.Map<RecipePOCO>(await Repository.SingleAsync<Recipe>(id));           
            }
            catch (Exception e)
            {
                throw e;
            }        
        }

        public virtual Task<int> InsertAsync(IRecipe entity)
        {
            try
            {
                return Repository.InsertAsync<Recipe>(Mapper.Map<Recipe>(entity));
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public virtual Task<int> UpdateAsync(IRecipe entity)
        {
            try
            {
                return Repository.UpdateAsync<Recipe>(Mapper.Map<Recipe>(entity));
            }

            catch (Exception e)
            {
                throw e;
            }     
        }

        public virtual Task<int> DeleteAsync(IRecipe entity)
        {
            try
            {
                return Repository.DeleteAsync<Recipe>(Mapper.Map<Recipe>(entity));
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public virtual Task<int> DeleteAsync(int id)
        {
            try
            {
                return Repository.DeleteAsync<Recipe>(Mapper.Map<Recipe>(id));
            }

            catch (Exception e)
            {
                throw e;
            }
        }


    }
      

}


        






     


