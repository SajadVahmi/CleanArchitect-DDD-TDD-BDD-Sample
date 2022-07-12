using Framework.Domain.Exceptions;

namespace Domain.Contracts.Customers.Exceptions
{
    public class InvalidCustomerLastnameException : DomainException
    {
        public InvalidCustomerLastnameException() : base(ExceptionCodes.INVALID_CUSTOMER_LASTNAME, ExceptionMessages.INVALID_CUSTOMER_LASTNAME)
        {

        }
    }

}
