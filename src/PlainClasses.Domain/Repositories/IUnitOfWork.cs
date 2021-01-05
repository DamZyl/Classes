using System.Threading.Tasks;
using PlainClasses.Domain.Models.Utils;

namespace PlainClasses.Domain.Repositories
{
    public interface IUnitOfWork
    {
        IGenericRepository<TEntity> Repository<TEntity>() where TEntity : class, IAggregateRoot;

        Task<int> CommitAsync();

        void Rollback();
    }
}