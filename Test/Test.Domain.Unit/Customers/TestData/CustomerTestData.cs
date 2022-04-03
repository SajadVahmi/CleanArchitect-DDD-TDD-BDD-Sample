using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Domain.Unit.Customers.TestData
{
    public static class CustomerTestData
    {
        public static Guid Id => Guid.Parse("877d0083-f5a4-4829-8447-69163961d281");
        public static string Firstname => "TestFirstname";
        public static string Lastname => "TestLastname";
        public static string Email => "test@email.com";
        
    }
}
