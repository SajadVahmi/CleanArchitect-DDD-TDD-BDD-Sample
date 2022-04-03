using Framework.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.Models.Contracts.DomainServices
{
    public interface ICustomerDomainService
    {
        Task<bool> ExistWithEmailAsync(Email email,CancellationToken cancellationToken=default);
            
    }
}
