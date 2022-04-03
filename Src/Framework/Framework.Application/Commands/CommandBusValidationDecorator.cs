using FluentValidation;
using Framework.Domain.Commands;
using Framework.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace Framework.Application.Commands
{
    public class CommandBusValidationDecorator : CommandBusDecorator
    {
        private readonly IServiceProvider serviceProvider;

        public CommandBusValidationDecorator(ICommandBus commandBus,
            IServiceProvider serviceProvider) : base(commandBus)
        {
            this.serviceProvider = serviceProvider;
        }
        public override async Task<CommandResult> Send<TCommand>(TCommand command)
        {
            var errors = Validate(command);
            if (errors != null)
            {
                CommandResult commandResult = new CommandResult();
                commandResult.Status = ResultStatus.ValidationError;
                commandResult.AddError(errors);
                return commandResult;
            }



            return await commandBus.Send(command);


        }

        public override async Task<CommandResult<TData>> Send<TCommand, TData>(TCommand command)
        {
            var errors = Validate(command);
            if (errors != null)
            {
                CommandResult<TData> commandResult = new CommandResult<TData>();
                commandResult.Status = ResultStatus.ValidationError;
                commandResult.AddError(errors);
                return commandResult;
            }



            return await commandBus.Send<TCommand, TData>(command);
        }

        private List<string> Validate<TCommand>(TCommand command)
        {
            var validator = serviceProvider.GetService<IValidator<TCommand>>();
            if (validator != null)
            {
                var validationResult = validator.Validate(command);

                if (!validationResult.IsValid)
                {
                    List<string> errors = new List<string>();
                    foreach (var failure in validationResult.Errors)
                    {
                        errors.Add(failure.ErrorMessage);
                    }
                    return errors;


                }
            }

            return null;

        }


    }
}
