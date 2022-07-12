using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Framework.Application.Common;

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
        public override async Task<Result> SendAsync<TCommand>(TCommand command)
        {
            var errors = Validate(command);
            if (errors != null)
            {
                Result commandResult = new Result();
                commandResult.Status = ResultStatus.ValidationError;
                commandResult.AddError(errors);
                return commandResult;
            }



            return await commandBus.SendAsync(command);


        }

        public override async Task<Result<TData>> SendAsync<TCommand, TData>(TCommand command)
        {
            var errors = Validate(command);
            if (errors != null)
            {
                Result<TData> commandResult = new Result<TData>();
                commandResult.Status = ResultStatus.ValidationError;
                commandResult.AddError(errors);
                return commandResult;
            }



            return await commandBus.SendAsync<TCommand, TData>(command);
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
