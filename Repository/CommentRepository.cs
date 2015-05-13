using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineCookbook.Repository.Common;
using OnlineCookbook.DAL.Models;
using OnlineCookbook.Model.Common;
using OnlineCookbook.Model;

namespace OnlineCookbook.Repository
{
   public class CommentRepository : ICommentRepository 
    {
       protected IRepository Repository { get; private set; }
        public IUnitOfWork UnitOfWork { get; private set; }

        public CommentRepository(IRepository repository)
        {
            Repository = repository;
        }

        public IUnitOfWork CreateUnitOfWork()
        {
            return Repository.CreateUnitOfWork();
        }

        public virtual Task<List<IComment>> GetAsync(string sortOrder = "commentId", int pageNumber = 0, int pageSize = 50)
        {
            throw new Exception("Not implemented!");
        }

        public virtual Task<IComment> GetAsync(Guid id)
        {
            throw new Exception("Not implemented!");
        }

        public virtual Task<int> InsertAsync(IComment entity)
        {
            throw new Exception("Not implemented!");
        }

        public virtual Task<int> UpdateAsync(IComment entity)
        {
            throw new Exception("Not implemented!");
        }

        public virtual Task<int> DeleteAsync(IComment entity)
        {
            throw new Exception("Not implemented!");
        }

        public virtual Task<int> DeleteAsync(Guid id)
        {
            throw new Exception("Not implemented!");
        }

    }
}
