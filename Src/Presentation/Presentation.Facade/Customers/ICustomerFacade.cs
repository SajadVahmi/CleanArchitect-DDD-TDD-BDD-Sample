using Domain.Contracts.Customers.Dtos;
using Framework.Application.Common;
using Presentation.Facade.Customers.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Facade.Customers
{
    public  interface ICustomerFacade
    {
        Task<Result<RegisteredCustomerDto>> RegisterCustomerAsync(RegisterCustomerDto dto, CancellationToken cancellationToken = default);
    }
}
