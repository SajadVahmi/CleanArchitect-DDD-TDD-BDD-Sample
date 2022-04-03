using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Test.RestApi.Integration.Customers
{
    public class BaseCustomerTests : IClassFixture<CustomWebApplicationFactory<ServiceHost.Startup>>
    {
        protected readonly HttpClient Client;
        protected readonly CustomWebApplicationFactory<ServiceHost.Startup>
            Factory;

        public BaseCustomerTests(
            CustomWebApplicationFactory<ServiceHost.Startup> factory)
        {
            this.Client = factory.CreateClient();
            this.Factory = factory;
        }
    }
}
