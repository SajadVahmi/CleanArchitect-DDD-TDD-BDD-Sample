using Framework.Domain.Commands;
using Framework.Domain.Common;
using Framework.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Application.Commands
{
    public class CommandBusDomainExceptionHandlerDecorator : CommandBusDecorator
    {

        public CommandBusDomainExceptionHandlerDecorator(ICommandBus commandBus) : base(commandBus)
        {

        }

        public override async Task<CommandResult> Send<TCommand>(TCommand command)
        {
            try
            {
                return await commandBus.Send(command);
            }
            catch (AppException ex)
            {

                return await DomainExceptionHandling<TCommand, CommandResult>(ex);
            }
            catch (Exception ex)
            {
                return await ExceptionHandling <TCommand, CommandResult>(ex);
            }


        }

        public override async Task<CommandResult<TData>> Send<TCommand, TData>(TCommand command)
        {
            try
            {
                return await commandBus .Send<TCommand, TData>(command);
            }
            catch (AppException ex)
            {
                return await DomainExceptionHandling<TCommand, CommandResult<TData>>(ex);
            }
            catch (Exception ex)
            {
                return await ExceptionHandling<TCommand, CommandResult<TData>>(ex);
            }

        }

        private Task<TCommandResult> DomainExceptionHandling<TCommand, TCommandResult>(AppException ex) where TCommandResult : Result, new()
        {
             var commandResult = CreateCommandResult<TCommandResult>(ex);

            commandResult.Status = ResultStatus.DomainException;
            return Task.FromResult(commandResult as TCommandResult);
        }
        private Task<TCommandResult> ExceptionHandling<TCommand, TCommandResult>(Exception ex) where TCommandResult : Result, new()
        {

            var commandResult = CreateCommandResult<TCommandResult>(ex);

            commandResult.Status = ResultStatus.Exception;
            return Task.FromResult(commandResult as TCommandResult);
        }

        private CommandResult CreateCommandResult<TCommandResult>(Exception ex)
        {
            var type = typeof(TCommandResult);
            dynamic commandResult = new CommandResult();
            if (type.IsGenericType)
            {
                var d1 = typeof(CommandResult<>);
                var makeme = d1.MakeGenericType(type.GetGenericArguments());
                commandResult = Activator.CreateInstance(makeme);
                commandResult.AddError(ex.Message);
            }
            else
                commandResult.AddError(ex.Message);

            return commandResult;
        }
    }
}
