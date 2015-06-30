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
        Task<T> SingleAsync<T>(string id) where T : class;
        Task<int> InsertAsync<T>(T entity) where T : class;
        Task<int> UpdateAsync<T>(T entity) where T : class;
        Task<int> DeleteAsync<T>(T entity) where T : class;
        Task<int> DeleteAsync<T>(string id) where T : class;

        
        Task<IEnumerable<T>> GetRangeAsync<T>(Expression<Func<T, bool>> match) where T : class;
        Task<IEnumerable<T>> GetRangeAsync<T>() where T : class;
        //za usera
        Task<int> AddAsync<T>(T entity) where T : class;

        Task<int> AddAsync<T>(IEnumerable<T> listOfEntities) where T : class;
        //za usera, provjeriti podudaranje usernamea i passworda
        Task<T> GetAsync<T>(Expression<Func<T, bool>> match) where T : class;
        
        Task<int> UpdateAsync<T>(T entity, params Expression<Func<T, object>>[] proportiesToUpdate) where T : class;
       

    }
}
