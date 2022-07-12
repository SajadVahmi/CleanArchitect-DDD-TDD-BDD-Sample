using Framework.Domain.Data;
using Framework.Domain.Entities;
using Framework.Persistence.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Framework.Persistence.Repositories
{
    public class Repository<TEntity, TKey, TDbContext> : IRepository<TEntity, TKey>
      where TEntity : AggregateRoot<TKey>
      where TDbContext : CommandDbContext
    {
        protected readonly TDbContext dbContext;
        public Repository(TDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<bool> ExistAsync(Expression<Func<TEntity, bool>> expersion, CancellationToken cancellationToken = default)
        {
            return await this.dbContext.Set<TEntity>().AnyAsync(expersion, cancellationToken);
        }

        public int SaveChanges()
        {
            return dbContext.SaveChanges();
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
