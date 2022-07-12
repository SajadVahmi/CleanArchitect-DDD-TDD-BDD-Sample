using Framework.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.Models.Customers
{
    public class CustomerDomainService : ICustomerDomainService
    {
        private readonly ICustomerRepository customerRepository;

        public CustomerDomainService(ICustomerRepository customerQueryRepository)
        {
            this.customerRepository = customerQueryRepository;
        }
        public async Task<bool> ExistWithEmailAsync(CustomerEmail email, CancellationToken cancellationToken = default)
        {
            return await customerRepository.ExistAsync(c=>c.Email.Value==email.Value, cancellationToken);
        }
    }
}
