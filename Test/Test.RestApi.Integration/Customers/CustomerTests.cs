using ServiceHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using Test.RestApi.Integration.Customers.Builders;
using Test.RestApi.Integration.Customers.Models;
using Test.RestApi.Integration.Customers.Routs;
using Xunit;

namespace Test.RestApi.Integration.Customers
{
    public class CustomerTests : BaseCustomerTests
    {
        public CustomerTests(CustomWebApplicationFactory<Startup> factory) : base(factory)
        {
        }

        [Fact]
        public async Task Post_WithValidCustomer_ReturnsCreatedResult()
        {
            var postRequest = new HttpRequestMessage(HttpMethod.Post, CustomerRouts.REGISTER_CUSTOMER);
            postRequest.Content = new CustomerInputJsonBuilder().Build();

            // Act
            var response = await Client.SendAsync(postRequest);

            Assert.Equal(HttpStatusCode.Created, response.StatusCode);

        }
    }
}
