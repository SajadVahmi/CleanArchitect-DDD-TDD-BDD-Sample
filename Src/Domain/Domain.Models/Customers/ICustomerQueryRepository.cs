using Framework.Domain.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.Models.Customers
{
    public interface ICustomerQueryRepository: IQueryRepository
    {
        Task<bool> ExistAsync(string email, CancellationToken cancellationToken = default);
    }
}
