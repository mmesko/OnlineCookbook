using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OnlineCookbook.Repository
{
    public interface IUnitOfWork : IDisposable
    {

        Task<int> CommitAsync();

        Task<int> AddAsync<T>(T entity) where T : class;
        Task<int> UpdateAsync<T>(T entity) where T : class;
        Task<T> UpdateObjectAsync<T>(T entity) where T : class;
        Task<T> UpdateAsync<T>(T entity, params Expression<Func<T, object>>[] entityParameters) where T : class;
        Task<int> DeleteAsync<T>(T entity) where T : class;
        Task<int> DeleteAsync<T>(string id) where T : class;
      

    }
}
