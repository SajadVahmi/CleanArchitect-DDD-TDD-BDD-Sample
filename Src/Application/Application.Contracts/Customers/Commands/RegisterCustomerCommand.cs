using Domain.Contracts.Customers.Dtos;
using Framework.Application.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts.Customers.Commands
{
    public class RegisterCustomerCommand : ICommand<RegisteredCustomerDto>
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
    }
}
