using Domain.Models.Contracts.DomainServices;
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
        private readonly ICustomerQueryRepository customerQueryRepository;

        public CustomerDomainService(ICustomerQueryRepository customerQueryRepository)
        {
            this.customerQueryRepository = customerQueryRepository;
        }
        public async Task<bool> ExistWithEmailAsync(Email email, CancellationToken cancellationToken = default)
        {
            return await customerQueryRepository.ExistAsync(email.Value, cancellationToken);
        }
    }
}
