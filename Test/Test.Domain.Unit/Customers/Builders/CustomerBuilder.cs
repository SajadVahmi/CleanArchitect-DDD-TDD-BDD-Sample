using Domain.Models.Customers;
using Framework.Domain.Clock;
using Framework.Domain.ValueObjects;
using Framework.TestTools;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Domain.Unit.Customers.TestData;

namespace Test.Domain.Unit.Customers.Builders
{
    public class CustomerBuilder
    {
        private Guid id;
        private string firstname;
        private string lastname;
        private string email;
        private IClock clock;
        private ICustomerDomainService customerDomainService;
        public CustomerBuilder()
        {
            id = CustomerTestData.Id;
            firstname = CustomerTestData.Firstname;
            lastname = CustomerTestData.Lastname;
            email = CustomerTestData.Email;
            clock = new ClockStub();
            customerDomainService = Substitute.For<ICustomerDomainService>();
            customerDomainService.ExistWithEmailAsync(Arg.Any<CustomerEmail>())
                                 .Returns(false);
        }

        public CustomerBuilder WithId(Guid id)
        {
            this.id = id;
            return this;
        }
        public CustomerBuilder WithFirstname(string firstname)
        {
            this.firstname = firstname;
            return this;
        }
        public CustomerBuilder WithLastname(string lastname)
        {
            this.lastname = lastname;
            return this;
        }
        public CustomerBuilder WithEmail(string email)
        {
            this.email = email;
            return this;
        }
        public CustomerBuilder WithClock(IClock clock)
        {
            this.clock = clock;
            return this;
        }
        public CustomerBuilder WithCustomerDomainService(ICustomerDomainService customerDomainService)
        {
            this.customerDomainService = customerDomainService;
            return this;
        }

        public async Task<Customer> Build()
        {
            return await Customer.Create(id: id,
                                    firstname: firstname,
                                    lastname: lastname,
                                    email: email,
                                    clock: clock,
                                    customerDomainService: customerDomainService);
        }

    }
}
