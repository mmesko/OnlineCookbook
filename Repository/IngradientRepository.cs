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
using OnlineCookbook.Filters.ModelFilter;
using System.Linq.Dynamic;


namespace OnlineCookbook.Repository
{
   public class IngradientRepository
    {
       protected IRepository Repository { get; private set; }

       public IngradientRepository(IRepository repository)
        {
            Repository = repository;       
        }

       public virtual async Task<List<IIngradient>> GetAsync(IngradientFilter filter)
        {
            try
            {
                return Mapper.Map<List<IIngradient>>(
                       await Repository.WhereAsync<Ingradient>()
                            .OrderBy(filter.SortOrder)
                            .Skip<Ingradient>((filter.PageNumber - 1) * filter.PageSize)
                            .Take<Ingradient>(filter.PageSize)
                            .ToListAsync<Ingradient>()
                    
                    
                    );//mapping from model to dal 
           }
            catch (Exception e)
            {
                throw e;
            }       
        }




       public virtual async Task<IIngradient> GetAsync(Guid id)
        {
            try 
            {
                return Mapper.Map<IngradientPOCO>(await Repository.SingleAsync<Ingradient>(id));           
            }
            catch (Exception e)
            {
                throw e;
            }        
        }

       public virtual Task<int> InsertAsync(IIngradient entity)
        {
            try
            {
                return Repository.InsertAsync<Ingradient>(Mapper.Map<Ingradient>(entity));
            }
            catch (Exception e)
            {
                throw e;
            }
        }

       public virtual Task<int> UpdateAsync(IIngradient entity)
        {
            try
            {
                return Repository.UpdateAsync<Ingradient>(Mapper.Map<Ingradient>(entity));
            }

            catch (Exception e)
            {
                throw e;
            }     
        }

       public virtual Task<int> DeleteAsync(IIngradient entity)
        {
            try
            {
                return Repository.DeleteAsync<Ingradient>(Mapper.Map<Ingradient>(entity));
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public virtual Task<int> DeleteAsync(Guid id)
        {
            try
            {
                return Repository.DeleteAsync<Ingradient>(Mapper.Map<Ingradient>(id));
            }

            catch (Exception e)
            {
                throw e;
            }
        }

    }
}
