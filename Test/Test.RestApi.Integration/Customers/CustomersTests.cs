using FluentAssertions;
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
    public class CustomersTests : BaseCustomersTests
    {
        public CustomersTests(CustomWebApplicationFactory<Startup> factory) : base(factory)
        {
        }

        [Fact]
        public async void post_with_valid_customer_return_created_status()
        {
            var postRequest = new HttpRequestMessage(HttpMethod.Post, CustomerRouts.REGISTER_CUSTOMER);
            postRequest.Content = new CustomerInputJsonBuilder().Build();
 
            var response =await Client.SendAsync(postRequest);
            
            response.StatusCode.Should().Be(HttpStatusCode.Created);

            
        }

        [Fact]
        public async void post_with_valid_customer_return_created_model()
        {
            var expectedModel=new CustumerCreatedModelBuilder()
                .WithFirstname("expectedFirstname")
                .WithLastname("expectedLastname")
                .WithEmail("expectedEmail@gmail.com")
                .Build();
            var postRequest = new HttpRequestMessage(HttpMethod.Post, CustomerRouts.REGISTER_CUSTOMER);
            postRequest.Content = new CustomerInputJsonBuilder()
                .WithFirstname(expectedModel.Firstname)
                .WithLastname(expectedModel.Lastname)
                .WithEmail(expectedModel.Email)
                .Build();

            var response =await Client.SendAsync(postRequest);
            var createdModel =await  response.Content.ReadFromJsonAsync<CustomerCreatedModel>();

            createdModel.Should().BeEquivalentTo(expectedModel, options => options.Excluding(ex =>(ex.Id))
                                                                                 .Excluding(ex=>ex.RegisterDate));
            createdModel.Id.Should().NotBe(default(Guid));
            createdModel.RegisterDate.Should().NotBe(default(DateTime));



        }

        [Theory]
        [MemberData(nameof(GetInvalidCustomerInformation))]
        public void post_with_invalid_costomer_information_return_bad_request(string firstName,string lastName,string email)
        {
            var postRequest = new HttpRequestMessage(HttpMethod.Post, CustomerRouts.REGISTER_CUSTOMER);
            postRequest.Content = new CustomerInputJsonBuilder()
                                      .WithFirstname(firstName)
                                      .WithLastname(lastName)
                                      .WithEmail(email)
                                      .Build();

            var response =  Client.SendAsync(postRequest).Result;

            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }
    }
}
