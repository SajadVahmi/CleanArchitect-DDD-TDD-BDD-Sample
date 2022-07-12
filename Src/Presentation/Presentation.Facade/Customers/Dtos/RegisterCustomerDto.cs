using Application.Commands.Customers.RegisterCustomerCommand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Facade.Customers.Dtos
{
    public  class RegisterCustomerDto
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }

        public RegisterCustomerCommand MapToCommand()
        {
            return new RegisterCustomerCommand()
            {
                Firstname = Firstname,
                Lastname = Lastname,
                Email = Email
            };
        }
    }
}
