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
   public class RecipePictureRepository : IRecipePictureRepository
    {
       IRepository repository;

       public RecipePictureRepository(IRepository repository)
        {
            this.repository = repository;
        }

        /// <summary>
        /// Get game image by id
        /// </summary>

       public virtual async Task<IRecipePicture> GetAsync(string id)
       {
           try
           {
               return Mapper.Map<IRecipePicture>(
                   await repository.SingleAsync<RecipePicture>(id));
           }
           catch (Exception e)
           {
               throw e;
           }
       }

        /// <summary>
        /// Get collection of game images
        /// </summary>
        /// <param name="filter">Filter, which provides options for pagination</param>
        /// <returns>GameImages collection</returns>
       public async Task<List<IRecipePicture>> GetRangeAsync(GenericFilter filter)
        {
            try
            {
                if (filter == null)
                    filter = new GenericFilter(1, 5);

                return Mapper.Map <List<IRecipePicture>>(await repository.WhereAsync<RecipePicture>()
                    .OrderBy(g => g.Id)
                    .Skip((filter.PageNumber * filter.PageSize) - filter.PageSize)
                    .Take(filter.PageSize).ToListAsync());
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        /// <summary>
        /// Get collection by fk
        /// </summary>
        /// <param name="gameId">Foreign key</param>
        /// <param name="filter">Filtering options</param>
        /// <returns>ICollection of IGameImage</returns>
        public async Task<List<IRecipePicture>> GetRangeAsync(string recipeId, GenericFilter filter)
        {
            try
            {
                if (filter == null)
                    filter = new GenericFilter(1, 5);

                return  Mapper.Map<List<IRecipePicture>>(await repository.WhereAsync<RecipePicture>()
                    .Where(g => g.RecipeId == recipeId)
                    .OrderBy(g => g.Id)
                   .Skip((filter.PageNumber * filter.PageSize) - filter.PageSize)
                   .Take(filter.PageSize).ToListAsync());
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        /// <summary>
        /// Add new game image to database
        /// </summary>
        /// <param name="gameImate">IGameImage to add</param>
        /// <returns>1 is success, 0 otherwise</returns>
        public async Task<int> InsertAsync(IRecipePicture entity)
        {
            try
            {
                return await repository.InsertAsync<RecipePicture>(
                    AutoMapper.Mapper.Map<RecipePicture>(entity)
                    );
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        /// <summary>
        /// Update existing game image
        /// </summary>
        /// <param name="gameImage">Game image to update</param>
        /// <returns>1 if success , 0 otherwise</returns>
        public async Task<int> UpdateAsync(IRecipePicture entity)
        {
            try
            {
                return await repository.UpdateAsync<RecipePicture>(
                    AutoMapper.Mapper.Map<RecipePicture>(entity)
                    );
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        /// <summary>
        /// Delete recipe image
        /// </summary>
        /// <param name="entity">recipe image to delete</param>
        /// <returns>1 if success , 0 otherwise</returns>
        public async Task<int> DeleteAsync(IRecipePicture entity)
        {
            try
            {
                return await repository.DeleteAsync<RecipePicture>(
                    AutoMapper.Mapper.Map<RecipePicture>(entity));
            }
            catch (Exception)
            {
                
                throw;
            }
        }

    }
}
