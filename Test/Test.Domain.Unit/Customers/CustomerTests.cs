using Domain.Contracts.Customers.Exceptions;
using Domain.Models.Customers;
using FluentAssertions;
using Framework.Domain.Exceptions;
using Framework.Domain.ValueObjects;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Domain.Unit.Customers.TestData;
using Xunit;

namespace Test.Domain.Unit.Customers
{
    public class CustomerTests:BaseCustomerTests
    {
       

       

        [Fact]
        public void each_customer_can_create_with_correct_information()
        {
            Customer sut = Customer.Create(id:CustomerTestData.Id,
                                           firstname: CustomerTestData.Firstname,
                                           lastname: CustomerTestData.Lastname,
                                           email: CustomerTestData.Email,
                                           clock:Clock,
                                           customerDomainService:CustomerDomainService)
                           .Result;

            sut.Id.Value.Should().Be(CustomerTestData.Id);
            sut.Name.Firstname.Should().Be(CustomerTestData.Firstname);
            sut.Name.Lastname.Should().Be(CustomerTestData.Lastname);
            sut.Email.Value.Should().Be(CustomerTestData.Email);
            sut.RegisterDate.Should().Be(Clock.Now());
        }

        [Theory]
        [MemberData(nameof(GetInvlidCustomerInformaion))]
        public  void not_allow_create_customer_with_invalid_information(Guid id,string firstname,string lastname,string email,Action<Func<Customer>> assert)
        {
           var act=() =>  Customer.Create(id:id,
                                             firstname:firstname,
                                             lastname: lastname,
                                             email:email,
                                             clock:Clock,
                                             customerDomainService:CustomerDomainService).Result;

             assert.Invoke(act);
            
        }

       [Fact]
       public async Task customer_cannot_create_with_an_existing_email()
        {
            CustomerDomainService.ExistWithEmailAsync(Arg.Any<CustomerEmail>()).Returns(true);

            Func<Task> act = async () => await Customer.Create(id: CustomerTestData.Id,
                                          firstname: CustomerTestData.Firstname,
                                          lastname: CustomerTestData.Lastname,
                                          email: CustomerTestData.Email,
                                          clock: Clock,
                                          customerDomainService: CustomerDomainService);

             await act.Should().ThrowAsync<CustomerExistWithThisEmailException>();
        }



        

    }
}
