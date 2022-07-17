using Application.Contracts.Customers.Commands;
using Domain.Contracts.Customers.Dtos;
using Framework.Application.Commands;
using Framework.Application.Common;
using Presentation.Facade.Customers.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Facade.Customers
{
    public  class CustomerFacade:ICustomerFacade
    {
        private readonly ICommandBus commandBus;

        public CustomerFacade(ICommandBus commandBus)
        {
            this.commandBus = commandBus;
        }

        public async Task<Result<RegisteredCustomerDto>> RegisterCustomerAsync(RegisterCustomerDto dto, CancellationToken cancellationToken = default)
        {
            var command = dto.MapToCommand();
            
            var registerCustomerResult=await commandBus.SendAsync<RegisterCustomerCommand, RegisteredCustomerDto>(command);

            return registerCustomerResult;


        }
    }
}
