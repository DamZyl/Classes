using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PlainClasses.Domain.Models.Utils;
using PlainClasses.Domain.Repositories;
using PlainClasses.Infrastructure.Databases.Sql;

namespace PlainClasses.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PlainClassesContext _context;
        private readonly Dictionary<Type, object> _repositories = new Dictionary<Type, object>();
        
        public UnitOfWork(PlainClassesContext context)
        {
            _context = context;
        }
        
        public IGenericRepository<TEntity> Repository<TEntity>() where TEntity : Entity
        {
            if (_repositories.Keys.Contains(typeof(TEntity)))
            {
                return _repositories[typeof(TEntity)] as IGenericRepository<TEntity>;
            }

            IGenericRepository<TEntity> repository = new GenericRepository<TEntity>(_context);
            _repositories.Add(typeof(TEntity), repository);
            return repository;
        }

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Rollback()
        {
            _context.ChangeTracker.Entries().ToList().ForEach(x => x.Reload());
        }
    }
}