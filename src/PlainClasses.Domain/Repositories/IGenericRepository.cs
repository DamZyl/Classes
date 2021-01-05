using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Query;
using PlainClasses.Domain.Models.Utils;

namespace PlainClasses.Domain.Repositories
{
    public interface IGenericRepository<in TEntity> where TEntity : class, IAggregateRoot
    {
        Task AddAsync(TEntity entity);
        Task AddRangeAsync(IEnumerable<TEntity> entities);
        void Edit(TEntity entity);
        Task EditAsync(TEntity entity);
        void EditRange(IEnumerable<TEntity> entities);
        Task EditRangeAsync(IEnumerable<TEntity> entities);
        void Delete(TEntity entity);
        Task DeleteAsync(TEntity entity);
        void DeleteRange(IEnumerable<TEntity> entities);
        Task DeleteRangeAsync(IEnumerable<TEntity> entities);
    }
}