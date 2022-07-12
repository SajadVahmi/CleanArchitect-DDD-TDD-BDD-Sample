using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contracts.Customers.Exceptions
{
    public static class ExceptionCodes
    {
        public const int INVALID_CUSTOMER_ID = 1000;
        public const int INVALID_CUSTOMER_EMAIL = 1001;
        public const int INVALID_CUSTOMER_FIRSTNAME = 1002;
        public const int INVALID_CUSTOMER_LASTNAME = 1003;
        public const int CUSTOMER_EXIST_WITH_THIS_EMAIL = 1004;
    }
}
