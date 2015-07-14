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
                if (filter == null)
                    filter = new AlergenFilter(1, 5);


                return Mapper.Map<List<IAlergen>>(
                    await Repository.WhereAsync<Alergen>()
                            .OrderBy(a => a.AlergenName)
                            .Skip((filter.PageNumber * filter.PageSize) - filter.PageSize)
                            .Take(filter.PageSize).ToListAsync()
                    );
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public virtual async Task<IAlergen> GetAsync(string id)
        {
            try 
            {
                return Mapper.Map<IAlergen>(await Repository.SingleAsync<Alergen>(id));           
            }
            catch (Exception e)
            {
                throw e;
            }        
        }

        public virtual async Task<List<IAlergen>> GetNameAsync(string name)
        {
            try
            {
                return Mapper.Map<List<IAlergen>>(
                    await Repository.WhereAsync<Alergen>()
                            .Where(item => item.AlergenName.Contains(name))
                            .ToListAsync<Alergen>()
                    );
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
                return Repository.DeleteAsync<Alergen>
                    (Mapper.Map<Alergen>(entity));
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
                return Repository.DeleteAsync<Alergen>(id);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}



    

