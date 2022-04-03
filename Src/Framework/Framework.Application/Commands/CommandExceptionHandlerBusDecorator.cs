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

        public override Task<CommandResult> Send<TCommand>(TCommand command)
        {
            try
            {
                return commandBus.Send(command);
            }
            catch (AppException ex)
            {

                return DomainExceptionHandling<TCommand, CommandResult>(ex);
            }
            catch (Exception ex)
            {
                return ExceptionHandling<TCommand, CommandResult>(ex);
            }


        }

        public override Task<CommandResult<TData>> Send<TCommand, TData>(TCommand command)
        {
            try
            {
                return commandBus.Send<TCommand, TData>(command);
            }
            catch (AppException ex)
            {
                return DomainExceptionHandling<TCommand, CommandResult<TData>>(ex);
            }
            catch (Exception ex)
            {
                return ExceptionHandling<TCommand, CommandResult<TData>>(ex);
            }

        }

        private Task<TCommandResult> DomainExceptionHandling<TCommand, TCommandResult>(AppException ex) where TCommandResult : Result, new()
        {
            var type = typeof(TCommandResult);
            dynamic commandResult = new CommandResult();
            if (type.IsGenericType)
            {
                var d1 = typeof(CommandResult<>);
                var makeme = d1.MakeGenericType(type.GetGenericArguments());
                commandResult = Activator.CreateInstance(makeme);
            }
            else
                commandResult.AddError(ex.Message);

            commandResult.Status = ResultStatus.DomainException;
            return Task.FromResult(commandResult as TCommandResult);
        }
        private Task<TCommandResult> ExceptionHandling<TCommand, TCommandResult>(Exception ex) where TCommandResult : Result, new()
        {
            var type = typeof(TCommandResult);
            dynamic commandResult = new CommandResult();
            if (type.IsGenericType)
            {
                var d1 = typeof(CommandResult<>);
                var makeme = d1.MakeGenericType(type.GetGenericArguments());
                commandResult = Activator.CreateInstance(makeme);
            }
            else
                commandResult.AddError(ex.Message);

            commandResult.Status = ResultStatus.Exception;
            return Task.FromResult(commandResult as TCommandResult);
        }
    }
}
