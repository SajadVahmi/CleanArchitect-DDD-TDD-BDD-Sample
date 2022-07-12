using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.RestApi.Integration.Customers.Models;
using Test.RestApi.Integration.Customers.TestData;

namespace Test.RestApi.Integration.Customers.Builders
{
    public class CustumerCreatedModelBuilder
    {
        private Guid id;
        private string firstname;
        private string lastname;
        private string email;
        private DateTime registerDate;

        public CustumerCreatedModelBuilder()
        {
            id = Guid.NewGuid();
            firstname = CustomerTestData.Firstname;
            lastname = CustomerTestData.Lastname;
            email = CustomerTestData.Email;
            registerDate = CustomerTestData.RegisterDate;

        }


        public CustumerCreatedModelBuilder WithId(Guid id)
        {
            this.id = id;
            return this;
        }
        public CustumerCreatedModelBuilder WithFirstname(string firstname)
        {
            this.firstname = firstname;
            return this;
        }
        public CustumerCreatedModelBuilder WithLastname(string lastname)
        {
            this.lastname = lastname;
            return this;
        }
        public CustumerCreatedModelBuilder WithEmail(string email)
        {
            this.email = email;
            return this;
        }

        public CustumerCreatedModelBuilder WithCreateDateTime(DateTime registerDate)
        {
            this.registerDate = registerDate;
            return this;
        }

        public CustomerCreatedModel Build()
        {
            return new CustomerCreatedModel()
            {
                Id = id,
                Firstname = firstname,
                Lastname = lastname,
                Email = email,
                RegisterDate = registerDate
            };
        }
    }
}
