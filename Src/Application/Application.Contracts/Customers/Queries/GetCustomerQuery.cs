using Framework.Application.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts.Customers.Queries
{
    public class GetCustomerQuery:IQuery
    {
        public Guid CustomerId { get; set; }
    }
}
