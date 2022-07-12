using Framework.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Framework.Domain.Data
{
    public interface IRepository<TEntity, TKey> : IUnitOfWork
       where TEntity : AggregateRoot<TKey>
    {
        Task<bool> ExistAsync(Expression<Func<TEntity,bool>> expersion, CancellationToken cancellationToken = default);
    }
}
