using Framework.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contracts.Customers.Exceptions
{
    public class InvalidCustomerEmailException : DomainException
    {
        public InvalidCustomerEmailException():base(ExceptionCodes.INVALID_CUSTOMER_EMAIL,ExceptionMessages.INVALID_CUSTOMER_EMAIL)
        {

        }
    }
}
