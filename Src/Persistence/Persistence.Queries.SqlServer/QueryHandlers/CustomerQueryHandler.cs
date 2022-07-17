using Application.Contracts.Customers.Queries;
using Domain.Contracts.Customers.Dtos;
using Framework.Application.Queries;
using Microsoft.EntityFrameworkCore;
using Persistence.Queries.SqlServer.DbContexts;
using Persistence.Queries.SqlServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Persistence.Queries.SqlServer.QueryHandlers
{
    public class CustomerQueryHandler : IQueryHandler<GetCustomerQuery, Customer>
    {
        private readonly AppQueryDbContext db;

        public CustomerQueryHandler(AppQueryDbContext db)
        {
            this.db = db;
        }
        public async Task<Customer> HandleAsync(GetCustomerQuery query, CancellationToken cancellationToken = default)
        {
            return await db.Customers.FirstOrDefaultAsync(c => c.Id == query.CustomerId);
        }
    }
}
