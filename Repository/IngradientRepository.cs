﻿using System;
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
using OnlineCookbook.Common.Filters;
using System.Linq.Dynamic;


namespace OnlineCookbook.Repository
{
   public class IngradientRepository : IIngradientRepository
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
                if (filter == null)
                    filter = new IngradientFilter(1, 5);


                return Mapper.Map<List<IIngradient>>(
                    await Repository.WhereAsync<Ingradient>()
                            .OrderBy(i => i.IngradientName)
                            .Skip((filter.PageNumber * filter.PageSize) - filter.PageSize)
                            .Take(filter.PageSize).ToListAsync()
                    );
            }
            catch (Exception e)
            {
                throw e;
            }
        }




       public virtual async Task<IIngradient> GetAsync(string id)
        {
            try 
            {
                return Mapper.Map<IIngradient>(await Repository.SingleAsync<Ingradient>(id));           
            }
            catch (Exception e)
            {
                throw e;
            }        
        }


       public virtual async Task<List<IIngradient>> GetNameAsync(string name)
       {
           try
           {
               return Mapper.Map<List<IIngradient>>(
                   await Repository.WhereAsync<Ingradient>()
                           .Where(item => item.IngradientName.Contains(name))
                           .ToListAsync<Ingradient>()
                   );
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
                return Repository.DeleteAsync<Ingradient >
                    (Mapper.Map<Ingradient >(entity));
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
                return Repository.DeleteAsync<Ingradient >(id);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }

    }

