using Domain.Models.Customers;
using Framework.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Persistence.Commands.SqlServer.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Persistence.Commands.SqlServer.Repositories
{
    public class CustomerCommandRepository : CommandRepository<Customer, CustomerId, AppCommandDbContext>, ICustomerCommandRepository
    {
        public CustomerCommandRepository(AppCommandDbContext dbContext) : base(dbContext) { }
        public void Add(Customer customer)
        {
            dbContext.Customers.Add(customer);


        }

        public void Delete(Customer customer)
        {
            dbContext.Customers.Remove(customer);

        }

        public async Task<Customer> FindAsync(CustomerId id, CancellationToken cancellationToken = default)
        {
            return await dbContext.Customers.FirstOrDefaultAsync(c => c.Id == id);
        }

        public int SaveChanges()
        {
            return dbContext.SaveChanges();
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await dbContext.SaveChangesAsync(cancellationToken);
        }

        public void Update(Customer customer)
        {
            dbContext.Customers.Update(customer);
        }
    }
}
