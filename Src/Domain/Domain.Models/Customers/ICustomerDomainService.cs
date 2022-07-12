using System.Threading;
using System.Threading.Tasks;
using Framework.Domain.ValueObjects;

namespace Domain.Models.Customers
{
    public interface ICustomerDomainService
    {
        Task<bool> ExistWithEmailAsync(CustomerEmail email,CancellationToken cancellationToken=default);
            
    }
}
