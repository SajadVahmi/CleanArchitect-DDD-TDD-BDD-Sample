using Domain.Contracts.Customers.Dtos;
using Domain.Models.Customers;
using Framework.Application.Commands;
using Framework.Application.Common;
using Framework.Domain.Clock;
using System;
using System.Threading.Tasks;


namespace Application.Commands.Customers.RegisterCustomerCommand
{
    public class RegisterCustomerCommandHandler : CommandHandler<RegisterCustomerCommand, RegisteredCustomerDto>
    {
        private readonly ICustomerRepository customerRepository;
        private readonly IClock clock;
        private readonly ICustomerDomainService customerDomainService;

        public RegisterCustomerCommandHandler(ICustomerRepository customerRepository, IClock clock, ICustomerDomainService customerDomainService)
        {
            this.customerRepository = customerRepository ?? throw new ArgumentNullException(nameof(customerRepository));
            this.clock = clock;
            this.customerDomainService = customerDomainService;
        }


        public override async Task<Result<RegisteredCustomerDto>> Handle(RegisterCustomerCommand command)
        {
            

            Customer customerForCreation = await Customer.Create(
                id: Guid.NewGuid(),
                firstname: command.Firstname,
                lastname: command.Lastname,
                email: command.Email,
                clock: clock,
                customerDomainService: customerDomainService
                );

            customerRepository.Add(customerForCreation);
            await customerRepository.SaveChangesAsync();


            
            RegisteredCustomerDto createdCustomer = new()
            {
                Id = customerForCreation.Id.Value,
                Firstname = customerForCreation.Name.Firstname,
                Lastname = customerForCreation.Name.Lastname,
                Email = customerForCreation.Email.Value,
                RegisterDate=customerForCreation.RegisterDate
            };

            return Ok(createdCustomer);
        }
    }
}
