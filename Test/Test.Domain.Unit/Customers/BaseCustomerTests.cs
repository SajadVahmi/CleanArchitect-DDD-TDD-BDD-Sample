using Domain.Models.Contracts.DomainServices;
using Domain.Models.Customers;
using Framework.Domain.ValueObjects;
using Framework.TestTools;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Domain.Unit.Customers
{
    public class BaseCustomerTests:BaseTests
    {
        public ICustomerDomainService CustomerDomainService { get; set; }
        public BaseCustomerTests()
        {
            CustomerDomainService = Substitute.For<ICustomerDomainService>();
            CustomerDomainService.ExistWithEmailAsync(Arg.Any<Email>())
                                 .Returns(false);
        }

        public static IEnumerable<object[]> GetInvlidCustomerInformaion()
        {
            yield return new object[] { default(Guid), Faker.Name.First(), Faker.Name.Last(), Faker.Internet.Email(), CustomerId.INVALID_ID_ERROR };
            yield return new object[] { Guid.Parse("310011f7-dc51-44b0-8743-7d9185dfee42"), null, Faker.Name.Last(), Faker.Internet.Email(), FullName.INAVLID_FIRST_OR_LAST_NAME_ERROR };
            yield return new object[] { Guid.Parse("310011f7-dc51-44b0-8743-7d9185dfee42"), string.Empty, Faker.Name.Last(), Faker.Internet.Email(), FullName.INAVLID_FIRST_OR_LAST_NAME_ERROR };
            yield return new object[] { Guid.Parse("310011f7-dc51-44b0-8743-7d9185dfee42"), Faker.Name.First(), null, Faker.Internet.Email(), FullName.INAVLID_FIRST_OR_LAST_NAME_ERROR };
            yield return new object[] { Guid.Parse("310011f7-dc51-44b0-8743-7d9185dfee42"), Faker.Name.First(), string.Empty, Faker.Internet.Email(), FullName.INAVLID_FIRST_OR_LAST_NAME_ERROR };
            yield return new object[] { Guid.Parse("310011f7-dc51-44b0-8743-7d9185dfee42"), Faker.Name.First(), Faker.Name.Last(), null, Email.INVALID_EMAIL_ERROR };
            yield return new object[] { Guid.Parse("310011f7-dc51-44b0-8743-7d9185dfee42"), Faker.Name.First(), Faker.Name.Last(), string.Empty, Email.INVALID_EMAIL_ERROR };
            yield return new object[] { Guid.Parse("310011f7-dc51-44b0-8743-7d9185dfee42"), Faker.Name.First(), Faker.Name.Last(), "@.Com", Email.INVALID_EMAIL_ERROR };
            yield return new object[] { Guid.Parse("310011f7-dc51-44b0-8743-7d9185dfee42"), Faker.Name.First(), Faker.Name.Last(), "123@Com", Email.INVALID_EMAIL_ERROR };

        }
    }
}
