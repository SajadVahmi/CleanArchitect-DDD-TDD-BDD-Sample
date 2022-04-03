using Domain.Models.Contracts.DomainServices;
using Domain.Models.Customers;
using Framework.Domain.Clock;
using Framework.Domain.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Customers
{
    public class RegisterCustomerCommandHandler : CommandHandler<RegisterCustomerCommand, RegisteredCustomerModel>
    {
        private readonly ICustomerCommandRepository customerCommandRepository;
        private readonly IClock clock;
        private readonly ICustomerDomainService customerDomainService;

        public RegisterCustomerCommandHandler(ICustomerCommandRepository customerCommandRepository,IClock clock, ICustomerDomainService customerDomainService)
        {
            this.customerCommandRepository = customerCommandRepository ?? throw new ArgumentNullException(nameof(customerCommandRepository));
            this.clock = clock;
            this.customerDomainService = customerDomainService;
        }


        public override async Task<CommandResult<RegisteredCustomerModel>> Handle(RegisterCustomerCommand command)
        {
            //TODO:Check customer exist with domain services

            Customer customerForCreation = await Customer.Create(
                id: Guid.NewGuid(),
                firstname: command.Firstname,
                lastname: command.Lastname,
                email: command.Email,
                clock:clock,
                customerDomainService:customerDomainService
                );

            customerCommandRepository.Add(customerForCreation);
            await customerCommandRepository.SaveChangesAsync();


            //TODO:Change this part with AutoMapper
            RegisteredCustomerModel createdCustomer = new()
            {
                Id = customerForCreation.Id.Value,
                Firstname = customerForCreation.Name.Firstname,
                Lastname = customerForCreation.Name.Lastname,
                Email = customerForCreation.Email.Value,
            };

            return Ok(createdCustomer);
        }
    }
}
