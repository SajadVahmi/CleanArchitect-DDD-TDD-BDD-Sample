using Framework.Domain.Data;
using Framework.Persistence.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Persistence.Repositories
{
    public class QueryRepository<TDbContext> : IQueryRepository
    where TDbContext : QueryDbContext
    {
        protected readonly TDbContext _dbContext;
        public QueryRepository(TDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}