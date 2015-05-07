using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using OnlineCookbook.DAL.Models;

namespace OnlineCookbook.Repository.Common
{
    public interface IRepository
    {

        IUnitOfWork CreateUnitOfWork();

        IQueryable<T> WhereAsync<T>() where T : class;
        Task<T> SingleAsync<T>(Guid id) where T : class;
        Task<int> InsertAsync<T>(T entity) where T : class;
        Task<int> UpdateAsync<T>(T entity) where T : class;
        Task<int> DeleteAsync<T>(T entity) where T : class;
        Task<int> DeleteAsync<T>(Guid id) where T : class;
       

    }
}
