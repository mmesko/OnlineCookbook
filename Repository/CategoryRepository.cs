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
    public class CategoryRepository : ICategoryRepository
    {

        protected IRepository Repository { get; private set; }
        public IUnitOfWork UnitOfWork { get; private set; }

        public CategoryRepository(IRepository repository)
        {
            Repository = repository;
        }

        public IUnitOfWork CreateUnitOfWork()
        {
            return Repository.CreateUnitOfWork();
        }

        public virtual Task<List<ICategory>> GetAsync(string sortOrder = "categoryId", int pageNumber = 0, int pageSize = 50)
        {
            throw new Exception("Not implemented!");
        }

        public virtual Task<ICategory> GetAsync(Guid id)
        {
            throw new Exception("Not implemented!");
        }

        public virtual Task<int> InsertAsync(ICategory entity)
        {
            throw new Exception("Not implemented!");
        }

        public virtual Task<int> UpdateAsync(ICategory entity)
        {
            throw new Exception("Not implemented!");
        }

        public virtual Task<int> DeleteAsync(ICategory entity)
        {
            throw new Exception("Not implemented!");
        }

        public virtual Task<int> DeleteAsync(Guid id)
        {
            throw new Exception("Not implemented!");
        }

    }
}
