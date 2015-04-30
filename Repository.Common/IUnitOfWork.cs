using System;
using System.Threading.Tasks;

namespace OnlineCookbook.Repository
{
    public interface IUnitOfWork : IDisposable
    {

        Task<int> CommitAsync();

        Task<int> AddAsync<T>(T entity) where T : class;
        Task<int> UpdateAsync<T>(T entity) where T : class;
        Task<int> DeleteAsync<T>(T entity) where T : class;
        Task<int> DeleteAsync<T>(int id) where T : class;

    }
}
