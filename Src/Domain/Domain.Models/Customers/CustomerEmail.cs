using System.Collections.Generic;
using System.Text.RegularExpressions;
using Domain.Contracts.Common;
using Domain.Contracts.Customers.Exceptions;
using Framework.Domain.Exceptions;
using Framework.Domain.ValueObjects;

namespace Domain.Models.Customers

{
    public class CustomerEmail : ValueObject<CustomerEmail>
    {
        
        
        public static CustomerEmail Create(string email) => new CustomerEmail(email);
        protected CustomerEmail() { }
        protected CustomerEmail(string email)
        {
            var regex = new Regex(Constants.EMAIL_REGEX);

            if (string.IsNullOrEmpty(email?.Trim()) || !regex.IsMatch(email))
                throw new InvalidCustomerEmailException();

            this.Value = email;
        }
        public string Value { get; private set; }
        protected override IEnumerable<object> GetAttributesToIncludeInEqualityCheck()
        {
            yield return Value;
        }
    }
}
