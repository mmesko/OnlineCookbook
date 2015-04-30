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
    public class AlergenRepository :  IAlergenRepository
    {
        protected IRepository Repository { get; private set; }

        public AlergenRepository(IRepository repository)
        {
            Repository = repository;       
        }

        public virtual async Task<List<IAlergen>> GetAsync(string sortOrder = "alergenId", int pageNumber = 1, int pageSize = 20)
        {
            try
            {
                //DAL list
                List<Alergen> page; //return page
                pageSize = (pageSize > 20) ? 20 : pageSize;

                switch (sortOrder)
                {
                    case "alergenId":
                        page = await Repository.WhereAsync<Alergen>()
                            .OrderBy(item => item.Id)
                            .Skip<Alergen>((pageNumber - 1) * pageSize)
                            .Take<Alergen>(pageSize) //whole page
                            .ToListAsync<Alergen>();
                        break;                 
                    default:
                        throw new ArgumentException();
                }
             return new List<IAlergen>(Mapper.Map<List<AlergenPOCO>>(page));//mapping from model to dal 
           }
            catch (Exception e)
            {
                throw e;
            }       
        }


        public virtual async Task<IAlergen> GetAsync(int id)
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

        public virtual Task<int> DeleteAsync(int id)
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



    

