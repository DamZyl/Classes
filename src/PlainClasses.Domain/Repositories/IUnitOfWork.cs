using System.Threading.Tasks;
using PlainClasses.Domain.Models.Utils;

namespace PlainClasses.Domain.Repositories
{
    public interface IUnitOfWork
    {
        IGenericRepository<TEntity> Repository<TEntity>() where TEntity : Entity;

        Task<int> CommitAsync();

        void Rollback();
    }
}