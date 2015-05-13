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
using OnlineCookbook.Filters.ModelFilter;



namespace OnlineCookbook.Repository
{
    public class AlergenRepository :  IAlergenRepository
    {
        protected IRepository Repository { get; private set; }

        public AlergenRepository(IRepository repository)
        {
            Repository = repository;       
        }


        public virtual async Task<List<IAlergen>> GetAsync(AlergenFilter filter)
        {
            try
            {
                return Mapper.Map<List<IAlergen>>(
                    await Repository.WhereAsync<Alergen>()
                            .OrderBy(filter.SortOrder)
                            .Skip<Alergen>((filter.PageNumber - 1) * filter.PageSize)
                            .Take<Alergen>(filter.PageSize)
                            .ToListAsync<Alergen>()
                    );
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public virtual async Task<IAlergen> GetAsync(Guid id)
        {
            try 
            {
                return Mapper.Map<AlergenPOCO>(await Repository.SingleAsync<Alergen>(id));           
            }
            catch (Exception e)
            {
                throw e;
            }        
        }

        public virtual Task<int> InsertAsync(IAlergen entity)
        {
            try
            {
                return Repository.InsertAsync<Alergen>(Mapper.Map<Alergen>(entity));
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public virtual Task<int> UpdateAsync(IAlergen entity)
        {
            try
            {
                return Repository.UpdateAsync<Alergen>(Mapper.Map<Alergen>(entity));
            }

            catch (Exception e)
            {
                throw e;
            }     
        }

        public virtual Task<int> DeleteAsync(IAlergen entity)
        {
            try
            {
                return Repository.DeleteAsync<Alergen>(Mapper.Map<Alergen>(entity));
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
                return Repository.DeleteAsync<Alergen>(Mapper.Map<Alergen>(id));
            }

            catch (Exception e)
            {
                throw e;
            }
        }
    }
}



    

