using System.Threading;
using System.Threading.Tasks;
using PlainClasses.Domain.Utils.SharedKernels;

namespace PlainClasses.Domain.Repositories
{
    public interface IUnitOfWork
    {
        IGenericRepository<TEntity> Repository<TEntity>() where TEntity : class, IAggregateRoot;

        Task<int> CommitAsync(CancellationToken cancellationToken = default(CancellationToken));

        void Rollback();
    }
}