

namespace OnlineCookbook.Repository.Common
{
    public interface IUnitOfWorkFactory
    {

        IUnitOfWork CreateUnitOfWork();
    }
}
