using System.Collections.Generic;
using Framework.Domain.Exceptions;
using Framework.Domain.ValueObjects;
using Domain.Contracts.Customers.Exceptions;

namespace Domain.Models.Customers
{
    public class CustomerFullName : ValueObject<CustomerFullName>
    {
       
        public static CustomerFullName Create(string firstname, string lastname) => new CustomerFullName(firstname, lastname);
        protected CustomerFullName() { }
        protected CustomerFullName(string firstname, string lastname)
        {
            if (string.IsNullOrEmpty(firstname?.Trim()))
                throw new InvalidCustomerFirstnameException();

            if(string.IsNullOrEmpty(lastname?.Trim()))
                throw new InvalidCustomerLastnameException();

            Firstname = firstname;

            Lastname = lastname;
        }



        public string Firstname { get; private set; }
        public string Lastname { get; private set; }
        protected override IEnumerable<object> GetAttributesToIncludeInEqualityCheck()
        {
            yield return Firstname;
            yield return Lastname;
        }
    }
}
