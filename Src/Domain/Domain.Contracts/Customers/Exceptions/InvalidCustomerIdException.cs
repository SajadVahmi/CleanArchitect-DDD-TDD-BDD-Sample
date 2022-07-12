using Framework.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contracts.Customers.Exceptions
{
    public  class InvalidCustomerIdException:DomainException
    {
        public InvalidCustomerIdException():base(ExceptionCodes.INVALID_CUSTOMER_ID,ExceptionMessages.INVALID_CUSTOMER_ID)
        {

        }
    }
}
