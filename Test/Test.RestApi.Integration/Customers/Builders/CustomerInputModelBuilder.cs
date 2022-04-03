using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using Test.RestApi.Integration.Customers.Models;
using Test.RestApi.Integration.Customers.TestData;

namespace Test.RestApi.Integration.Customers.Builders
{
    public class CustomerInputJsonBuilder
    {

        private string firstname;
        private string lastname;
        private string email;
     
        public CustomerInputJsonBuilder()
        {
          
            firstname = CustomerTestData.Firstname;
            lastname = CustomerTestData.Lastname;
            email = CustomerTestData.Email;
           
        }

       

        public CustomerInputJsonBuilder WithFirstname(string firstname)
        {
            this.firstname = firstname;
            return this;
        }
        public CustomerInputJsonBuilder WithLastname(string lastname)
        {
            this.lastname = lastname;
            return this;
        }
        public CustomerInputJsonBuilder WithEmail(string email)
        {
            this.email = email;
            return this;
        }
      
       

        public JsonContent Build()
        {
            var customer = new CustomerInputModel()
            {
                Firstname = this.firstname,
                Lastname = this.lastname,
                Email = this.email
            };
            return JsonContent.Create(customer);
        }

    }
}
