
using Framework.Application.Common;
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

        public override async Task<Result> SendAsync<TCommand>(TCommand command)
        {
            try
            {
                return await commandBus.SendAsync(command);
            }
            catch (DomainException ex)
            {

                return await DomainExceptionHandling<TCommand, Result>(ex);
            }
            catch (Exception ex)
            {
                return await ExceptionHandling <TCommand, Result>(ex);
            }


        }

        public override async Task<Result<TData>> SendAsync<TCommand, TData>(TCommand command)
        {
            try
            {
                return await commandBus .SendAsync<TCommand, TData>(command);
            }
            catch (DomainException ex)
            {
                return await DomainExceptionHandling<TCommand, Result<TData>>(ex);
            }
            catch (Exception ex)
            {
                return await ExceptionHandling<TCommand, Result<TData>>(ex);
            }

        }

        private Task<TCommandResult> DomainExceptionHandling<TCommand, TCommandResult>(DomainException ex) where TCommandResult : Result, new()
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

        private Result CreateCommandResult<TCommandResult>(Exception ex)
        {
            var type = typeof(TCommandResult);
            dynamic commandResult = new Result();
            if (type.IsGenericType)
            {
                var d1 = typeof(Result<>);
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
