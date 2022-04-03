using Domain.Models.Customers;
using Framework.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Persistence.Queries.SqlServer.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Persistence.Queries.SqlServer.Repositories
{
    public class CustomerQueryRepository : QueryRepository<AppQueryDbContext>,ICustomerQueryRepository
    {
        public CustomerQueryRepository(AppQueryDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<bool> ExistAsync(string email, CancellationToken cancellationToken = default)
        {
            return  await _dbContext.Customers.AnyAsync(c => c.Email == email, cancellationToken);
        }
    }
}
