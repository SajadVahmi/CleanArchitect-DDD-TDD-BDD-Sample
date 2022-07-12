using Application.Commands.Customers;
using Application.Commands.Customers.RegisterCustomerCommand;
using AutoMapper;
using Domain.Contracts.Customers.Dtos;
using Framework.Application.Commands;
using Framework.Application.Common;
using Framework.Application.RestApi;
using Microsoft.AspNetCore.Mvc;
using Presentation.Facade.Customers;
using Presentation.Facade.Customers.Dtos;
using Presentation.RestApi.Customers.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Presentation.RestApi.Customers.Controllers
{
    [Route("api/[controller]")]
    public class CustomersController : ApiController
    {
        private readonly ICustomerFacade customerFacade;
        private readonly IMapper mapper;

        public CustomersController(ICustomerFacade customerFacade, IMapper mapper)
        {
            this.customerFacade = customerFacade;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> RegisterAsync([FromBody]RegisterCustomerRequest request,CancellationToken cancellationToken=default)
        {
            RegisterCustomerDto registerCustomerDto = mapper.Map<RegisterCustomerDto>(request);

            var result = await customerFacade.RegisterCustomerAsync(registerCustomerDto);

            if (result.Status == ResultStatus.Ok)
                return Created(string.Empty, result.Data);
            else
                return BadRequest();
        }
    }
}
