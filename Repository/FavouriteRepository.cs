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
   public class FavouriteRepository : IFavouriteRepository
    {
       protected IRepository Repository { get; private set; }
        public FavouriteRepository(IRepository repository)
        {
            Repository = repository;       
        }

        public virtual async Task<List<IFavourite>> GetAsync(string recipeId, FavouriteFilter filter = null)
        {
            try
            {
                if (filter == null)
                    filter = new FavouriteFilter(1, 5);


                return Mapper.Map<List<IFavourite>>(
                    await Repository.WhereAsync<Favourite>()
                            .Where(item=>item.RecipeId == recipeId)
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

        public virtual async Task<IFavourite> GetAsync(string id)
        {
            try
            {
                return Mapper.Map<IFavourite>(await Repository.SingleAsync<Favourite>(id));
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public virtual async Task<List<IFavourite>> GetNameAsync(string name)
        {
            try
            {
                return Mapper.Map<List<IFavourite>>(
                    await Repository.WhereAsync<Favourite>()
                            .Where(item => item.FavouriteName.Contains(name))
                            .ToListAsync()
                    );
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public virtual Task<int> InsertAsync(IFavourite entity)
        {
            try
            {
                
                return Repository.InsertAsync<Favourite>(Mapper.Map<Favourite>(entity));
            }
            catch (Exception e)
            {
                throw e;
            }
        }
       
       //update with add?
        public virtual Task<int> UpdateAsync(IFavourite entity)
        {
            try
            {
                return Repository.UpdateAsync<Favourite>(Mapper.Map<Favourite>(entity));
            }

            catch (Exception e)
            {
                throw e;
            }
        }


        public virtual Task<int> DeleteAsync(IFavourite entity)
        {
            try
            {
                return Repository.DeleteAsync<Favourite>(Mapper.Map<Favourite>(entity));
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
                return Repository.DeleteAsync<Favourite>(Mapper.Map<Favourite>(id));
            }

            catch (Exception e)
            {
                throw e;
            }
        }

    }
}
