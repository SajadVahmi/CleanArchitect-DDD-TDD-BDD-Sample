using Domain.Models.Customers;
using Framework.Domain.ValueObjects;
using Framework.TestTools;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Contracts.Customers.Exceptions;
using FluentAssertions;

namespace Test.Domain.Unit.Customers
{
    public class BaseCustomerTests:BaseTests
    {
        public ICustomerDomainService CustomerDomainService { get; set; }
        public BaseCustomerTests()
        {
            CustomerDomainService = Substitute.For<ICustomerDomainService>();
            CustomerDomainService.ExistWithEmailAsync(Arg.Any<CustomerEmail>())
                                 .Returns(false);
        }

        public static IEnumerable<object[]> GetInvlidCustomerInformaion()
        {
            yield return new object[] { default(Guid), Faker.Name.First(), Faker.Name.Last(), Faker.Internet.Email(),new Action<Func<Customer>>(act=>{act.Should().Throw<InvalidCustomerIdException>().WithMessage(ExceptionMessages.INVALID_CUSTOMER_ID);}) };
            
            yield return new object[] { Guid.Parse("310011f7-dc51-44b0-8743-7d9185dfee42"), null, Faker.Name.Last(), Faker.Internet.Email(), new Action<Func<Customer>>(act => { act.Should().Throw<InvalidCustomerFirstnameException>().WithMessage(ExceptionMessages.INVALID_CUSTOMER_FIRSTNAME); }) };
            
            yield return new object[] { Guid.Parse("310011f7-dc51-44b0-8743-7d9185dfee42"), string.Empty, Faker.Name.Last(), Faker.Internet.Email(), new Action<Func<Customer>>(act => { act.Should().Throw<InvalidCustomerFirstnameException>().WithMessage(ExceptionMessages.INVALID_CUSTOMER_FIRSTNAME); }) };
            
            yield return new object[] { Guid.Parse("310011f7-dc51-44b0-8743-7d9185dfee42"), Faker.Name.First(), null, Faker.Internet.Email(), new Action<Func<Customer>>(act => { act.Should().Throw<InvalidCustomerLastnameException>().WithMessage(ExceptionMessages.INVALID_CUSTOMER_LASTNAME); }) };
            
            yield return new object[] { Guid.Parse("310011f7-dc51-44b0-8743-7d9185dfee42"), Faker.Name.First(), string.Empty, Faker.Internet.Email(), new Action<Func<Customer>>(act => { act.Should().Throw<InvalidCustomerLastnameException>().WithMessage(ExceptionMessages.INVALID_CUSTOMER_LASTNAME); }) };
            
            yield return new object[] { Guid.Parse("310011f7-dc51-44b0-8743-7d9185dfee42"), Faker.Name.First(), Faker.Name.Last(), null, new Action<Func<Customer>>(act => { act.Should().Throw<InvalidCustomerEmailException>().WithMessage(ExceptionMessages.INVALID_CUSTOMER_EMAIL); }) };
            
            yield return new object[] { Guid.Parse("310011f7-dc51-44b0-8743-7d9185dfee42"), Faker.Name.First(), Faker.Name.Last(), string.Empty, new Action<Func<Customer>>(act => { act.Should().Throw<InvalidCustomerEmailException>().WithMessage(ExceptionMessages.INVALID_CUSTOMER_EMAIL); }) };
            
            yield return new object[] { Guid.Parse("310011f7-dc51-44b0-8743-7d9185dfee42"), Faker.Name.First(), Faker.Name.Last(), "@.Com", new Action<Func<Customer>>(act => { act.Should().Throw<InvalidCustomerEmailException>().WithMessage(ExceptionMessages.INVALID_CUSTOMER_EMAIL); }) };
            
            yield return new object[] { Guid.Parse("310011f7-dc51-44b0-8743-7d9185dfee42"), Faker.Name.First(), Faker.Name.Last(), "123@Com", new Action<Func<Customer>>(act => { act.Should().Throw<InvalidCustomerEmailException>().WithMessage(ExceptionMessages.INVALID_CUSTOMER_EMAIL); }) };

        }
    }
}
