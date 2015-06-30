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
                if (filter != null)
                {
                    return Mapper.Map<List<IRecipe>>(
                        await Repository.WhereAsync<Recipe>()
                                 .OrderBy(filter.SortOrder)
                                 .Skip<Recipe>((filter.PageNumber - 1) * filter.PageSize)
                                 .Take<Recipe>(filter.PageSize)
                                 .Include(item => item.RecipePictures)
                                 .ToListAsync<Recipe>()
                                 );
                }
                else // return all
                {
                    return Mapper.Map<List<IRecipe>>(
                        await Repository.WhereAsync<Recipe>()
                        .Include(item => item.RecipePictures)
                        .ToListAsync()
                        );
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }



        public virtual async Task<IRecipe> GetAsync(string id)
        {
            try
            {
                return Mapper.Map<IRecipe>(
                    await Repository.WhereAsync<Recipe>()
                    .Where(item => item.Id == id)
                    .Include(item => item.RecipePictures)
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
                if (filter != null)
                {
                    return Mapper.Map<List<IRecipe>>(
                        await Repository.WhereAsync<Recipe>()
                         .Where<Recipe>(item => item.CategoryId == categoryId)
                         .OrderBy(filter.SortOrder)
                         .Skip<Recipe>((filter.PageNumber - 1) * filter.PageSize)
                         .Take<Recipe>(filter.PageSize)
                         .Include(item => item.RecipePictures)
                         .ToListAsync<Recipe>()

                        );
                }
                else
                {
                    return Mapper.Map<List<IRecipe>>(
                     await Repository.WhereAsync<Recipe>()
                      .Where<Recipe>(item => item.CategoryId == categoryId)
                      .OrderBy(filter.SortOrder)
                      .Include(item => item.RecipePictures)
                      .ToListAsync<Recipe>()
                     );
                }
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

        public virtual Task<int> AddAsync(IUnitOfWork unitOfWork, IRecipe entity)
        {
            try
            {
                return unitOfWork.AddAsync<Recipe>(
                    Mapper.Map<Recipe>(entity));
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

        private async Task<int> DeleteAsync(IUnitOfWork unitOfWork, Recipe entity)
        {
            try
            {
                var result = 0;

                var pictures = await Repository.WhereAsync<RecipePicture>()
                    .Where(item => item.RecipeId == entity.Id)
                    .ToListAsync();

                foreach (var picture in pictures)
                {
                    result += await unitOfWork.DeleteAsync<RecipePicture>(picture);
                }

                result += await unitOfWork.DeleteAsync<Recipe>(entity);

                return result;
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        public Task<int> DeleteAsync(IUnitOfWork unitOfWork, IRecipe entity)
        {
            try
            {
                return this.DeleteAsync(unitOfWork,
                    Mapper.Map<Recipe>(entity));
            }
            catch (Exception e)
            {
                throw e;
            }
        }


       public async Task<int> DeleteAsync(IUnitOfWork unitOfWork, string id)
        {
            try
            {
                return await DeleteAsync(
                    unitOfWork, await Repository.SingleAsync<Recipe>(id));
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


        






     


