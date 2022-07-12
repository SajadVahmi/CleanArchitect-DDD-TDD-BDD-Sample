using Framework.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contracts.Customers.Exceptions
{
    public  class InvalidCustomerFirstnameException:DomainException
    {
        public InvalidCustomerFirstnameException():base(ExceptionCodes.INVALID_CUSTOMER_FIRSTNAME, ExceptionMessages.INVALID_CUSTOMER_FIRSTNAME)
        {

        }
    }

}
