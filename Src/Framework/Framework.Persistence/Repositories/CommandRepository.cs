using Framework.Domain.Data;
using Framework.Domain.Entities;
using Framework.Persistence.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Framework.Persistence.Repositories
{
    public class CommandRepository<TEntity, TKey, TDbContext> : ICommandRepository<TEntity, TKey>
      where TEntity : AggregateRoot<TKey>
      where TDbContext : CommandDbContext
    {
        protected readonly TDbContext dbContext;
        public CommandRepository(TDbContext dbContext)
        {
            this.dbContext = dbContext;
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
