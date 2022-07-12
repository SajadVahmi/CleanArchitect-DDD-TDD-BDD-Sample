using Framework.Domain.Clock;
using Framework.Domain.Entities;
using Framework.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Contracts.Customers.Exceptions;

namespace Domain.Models.Customers
{
    public class Customer:AggregateRoot<CustomerId>
    {
        protected Customer()
        {

        }
        protected Customer(Guid id, string firstname, string lastname, CustomerEmail email, IClock clock)
        {
            Id = CustomerId.FromGuid(id);

            Name = CustomerFullName.Create(firstname, lastname);

            Email = email;
           
            RegisterDate = clock.Now();


        }

        public static async Task<Customer> Create(Guid id, string firstname, string lastname, string email, IClock clock,ICustomerDomainService customerDomainService)
        {
            CustomerEmail emailObject= CustomerEmail.Create(email);

            bool customerExistWithEmail = customerDomainService.ExistWithEmailAsync(emailObject).Result;

            if (customerExistWithEmail)
                throw new CustomerExistWithThisEmailException();

            return new Customer(id, firstname, lastname, emailObject, clock);
        }

        public CustomerFullName Name { get; protected set; }
        public CustomerEmail Email { get; protected set; }
        public DateTime RegisterDate { get; protected set; }
        
    }
}
