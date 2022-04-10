using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Test.RestApi.Integration.Customers
{
    public class BaseCustomersTests : IClassFixture<CustomWebApplicationFactory<ServiceHost.Startup>>
    {
        protected readonly HttpClient Client;
        protected readonly CustomWebApplicationFactory<ServiceHost.Startup>
            Factory;

        public BaseCustomersTests(
            CustomWebApplicationFactory<ServiceHost.Startup> factory)
        {
            this.Client = factory.CreateClient();
            this.Factory = factory;
        }

        public static IEnumerable<object[]> GetInvalidCustomerInformation()
        {

            yield return new object[] { string.Empty, TestData.CustomerTestData.Lastname, TestData.CustomerTestData.Email };
            yield return new object[] { null, TestData.CustomerTestData.Lastname, TestData.CustomerTestData.Email };
            yield return new object[] { "   ", TestData.CustomerTestData.Lastname, TestData.CustomerTestData.Email };

            yield return new object[] { TestData.CustomerTestData.Firstname, null, TestData.CustomerTestData.Email };
            yield return new object[] { TestData.CustomerTestData.Firstname, string.Empty, TestData.CustomerTestData.Email };
            yield return new object[] { TestData.CustomerTestData.Firstname, "   ", TestData.CustomerTestData.Email };


            yield return new object[] { TestData.CustomerTestData.Firstname, TestData.CustomerTestData.Lastname, "www.google.com" };
            yield return new object[] { TestData.CustomerTestData.Firstname, TestData.CustomerTestData.Lastname, null };
            yield return new object[] { TestData.CustomerTestData.Firstname, TestData.CustomerTestData.Lastname, string.Empty };
            yield return new object[] { TestData.CustomerTestData.Firstname, TestData.CustomerTestData.Lastname, "   " };
        }
    }
}
