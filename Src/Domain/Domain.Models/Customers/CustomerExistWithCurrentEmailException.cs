using Framework.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Customers
{
    public class CustomerExistWithCurrentEmailException : AppException
    {
        public const string ERROR_MESSAGE = "User already exist with current email";
        public CustomerExistWithCurrentEmailException() : base(ERROR_MESSAGE)
        {
        }
    }
}
