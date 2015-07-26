using System;
using AutoMapper;
using System.Data.Entity;
using System.Linq;
using System.Linq.Dynamic;
using System.Collections.Generic;
using System.Threading.Tasks;
using OnlineCookbook.Repository.Common;
using OnlineCookbook.DAL.Models;
using OnlineCookbook.Model.Common;
using OnlineCookbook.Common.Filters;


namespace OnlineCookbook.Repository
{
    public class RecipeRepository : IRecipeRepository
    {
        
        protected IRepository Repository { get; private set; }
       
       

        public RecipeRepository(IRepository repository)
        {
            Repository = repository;       
        }



        public virtual async Task<List<IRecipe>> GetAsync(RecipeFilter filter = null)
        {
            try
            {
                if (filter == null)
                    filter = new RecipeFilter(1, 5);


                return Mapper.Map<List<IRecipe>>(
                    await Repository.WhereAsync<Recipe>()
                            .OrderBy(a => a.RecipeTitle)
                            .Skip((filter.PageNumber * filter.PageSize) - filter.PageSize)
                            .Take(filter.PageSize).ToListAsync()
                    );
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public virtual async Task<List<IRecipe>> GetAsync(string ingradientId, RecipeFilter filter =null)
        {
            try
            {
                if (filter == null)
                    filter = new RecipeFilter(1,5);
                //Any() returns bool
                var result = await Repository.WhereAsync<Recipe>()
                     .Where(t => t.RecipeIngradients.Where(c => c.IngradientId == ingradientId).Any())
                     .OrderBy(a => a.RecipeTitle)
                     .Skip((filter.PageNumber * filter.PageSize) - filter.PageSize)
                     .Take(filter.PageSize).ToListAsync();
                     
                return Mapper.Map<List<IRecipe>>(result);

            }
            catch (Exception e)
            {
                throw e.InnerException;
            }
        
        }

        public virtual async Task<IRecipe> GetAsync(string id)
        {
            try
            {
                return Mapper.Map<IRecipe>(
                    await Repository.WhereAsync<Recipe>()
                    .Where(item => item.Id == id)
                    .SingleAsync()
                    );
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public virtual async Task<List<IRecipe>> GetByNameAsync(string name)
        {
            try
            {
                return Mapper.Map<List<IRecipe>>(
                    await Repository.WhereAsync<Recipe>()
                    .Where(r=>r.RecipeTitle.Contains(name))
                    .ToListAsync<Recipe>()
                    );
            }
            catch (Exception e)
            {
                throw e;
            }
        
        }

        public async virtual Task<List<IRecipe>> GetByCategoryAsync(string categoryId, RecipeFilter filter = null)
        {
            try
            {
                if (filter == null)
                    filter = new RecipeFilter(1, 5);


                return Mapper.Map<List<IRecipe>>(
                    await Repository.WhereAsync<Recipe>()
                             .Where(item=>item.CategoryId==categoryId)
                            .OrderBy(a => a.RecipeTitle)
                            .Skip((filter.PageNumber * filter.PageSize) - filter.PageSize)
                            .Take(filter.PageSize).ToListAsync()
                    );
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


        private async Task<int> DeleteAsync(Recipe entity)
        {
            try
            {
                var unitOfWork = Repository.CreateUnitOfWork(); // mogla sam staviti i gore kao parametar?
                var result = 0;

                var comments = await Repository.WhereAsync<Comment>()
                    .Where(item => item.RecipeId == entity.Id)
                    .ToListAsync();

                foreach (var comment in comments)
                {
                    result += await unitOfWork.DeleteAsync<Comment>(comment);
                }

                result += await unitOfWork.DeleteAsync<Recipe>(entity);

                return result;

            }
            catch (Exception e)
            {

                throw e;
            }

        }

        //private async Task<int> DeleteAsync(IUnitOfWork unitOfWork, Recipe entity)
        //{
        //    try
        //    {
        //        var result = 0;

        //        var pictures = await Repository.WhereAsync<RecipePicture>()
        //            .Where(item => item.RecipeId == entity.Id)
        //            .ToListAsync();

        //        foreach (var picture in pictures)
        //        {
        //            result += await unitOfWork.DeleteAsync<RecipePicture>(picture);
        //        }

        //        result += await unitOfWork.DeleteAsync<Recipe>(entity);

        //        return result;
        //    }
        //    catch (Exception e)
        //    {
        //        throw e;
        //    }
        //}


        public Task<int> DeleteAsync(IRecipe entity)
        {
            try
            {
                return this.DeleteAsync(Mapper.Map<Recipe>(entity));
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
                return await DeleteAsync(await Repository.SingleAsync<Recipe>(id));
            }
            catch (Exception e)
            {
                throw e;
            }
        }

       public Task<IUnitOfWork> CreateUnitOfWork()
       {
           try
           {
               return Task.FromResult(Repository.CreateUnitOfWork());
           }
           catch (Exception e)
           {
               throw e;
           }
       }

    }  
 

}


        






     


