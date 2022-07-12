using System;
using System.Threading;
using System.Threading.Tasks;
using Framework.Domain.Data;

namespace Domain.Models.Customers
{
    public interface ICustomerRepository : IRepository<Customer, CustomerId>
    {
        
        Task<bool> ExistAsync(CustomerId customerId, CancellationToken cancellationToken = default);
        Task<Customer> FindAsync(CustomerId id, CancellationToken cancellationToken = default);
        void Add(Customer customer);
        void Update(Customer customer);
        void Delete(Customer customer);

    }
}
