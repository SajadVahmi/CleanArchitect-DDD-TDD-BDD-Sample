using Framework.Domain.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.Models.Customers
{
    public interface ICustomerCommandRepository : ICommandRepository<Customer, CustomerId>
    {
        Task<Customer> FindAsync(CustomerId id, CancellationToken cancellationToken = default);
        void Add(Customer customer);
        void Update(Customer customer);
        void Delete(Customer customer);

    }
}
