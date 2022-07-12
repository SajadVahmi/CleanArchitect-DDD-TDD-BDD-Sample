using Framework.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contracts.Customers.Exceptions
{
    public class CustomerExistWithThisEmailException:DomainException
    {
        public CustomerExistWithThisEmailException():base(ExceptionCodes.CUSTOMER_EXIST_WITH_THIS_EMAIL,ExceptionMessages.INVALID_CUSTOMER_ID)
        {

        }
    }
}
