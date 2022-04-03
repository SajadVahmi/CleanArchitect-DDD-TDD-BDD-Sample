using Application.Commands.Customers;
using Framework.Application.RestApi;
using Framework.Domain.Commands;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.RestApi.Customers
{
    [Route("api/[controller]")]
    public class CustomersController : ApiController
    {
        ICommandBus bus;
        public CustomersController(ICommandBus bus)
        {
            this.bus = bus;
        }

        [HttpPost]
        public async Task<IActionResult> Post(RegisterCustomerCommand command)
        {


            var result = await bus.Send<RegisterCustomerCommand, RegisteredCustomerModel>(command);

            //TODO: Add Return From CommndResult To Base Api Controller 
            return Created(string.Empty, result.Data);
        }
    }
}
