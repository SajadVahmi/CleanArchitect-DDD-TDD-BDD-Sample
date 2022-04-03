using Framework.Domain.Commands;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Application.Commands
{
    public class CommandBusLoggingDecorator : CommandBusDecorator
    {
        private readonly ILogger<CommandBusLoggingDecorator> logger;

        public CommandBusLoggingDecorator(ICommandBus commandBus, ILogger<CommandBusLoggingDecorator> logger) : base(commandBus)
        {
            this.logger = logger;
        }

        public async override Task<CommandResult> Send<TCommand>(TCommand command)
        {
            Guid commandId = Guid.NewGuid();
            Log(commandId, command);
            var result = await commandBus.Send(command);
            Log(commandId, command, result);
            return result;


        }

        public async override Task<CommandResult<TData>> Send<TCommand, TData>(TCommand command)
        {
            Guid commandId = Guid.NewGuid();
            Log(commandId, command);
            var result = await commandBus.Send<TCommand, TData>(command);
            Log(commandId, command, result.Data, result);
            return result;
        }


        private void Log<TCommand>(Guid commandId, TCommand command) =>
            logger.LogInformation("{CommandName} with Id: {@CommandId} started with {@CommandInput} in {DateTime}", command.GetType().Name, commandId, command, DateTime.UtcNow);

        private void Log<TCommand>(Guid commandId, TCommand command, CommandResult result)
            => logger.LogInformation("{CommandName} with Id: {@CommandId} finished with {@CommandResult} in {FinishDateTime}", command.GetType().Name, commandId, result, DateTime.UtcNow);

        private void Log<TCommand, TData>(Guid commandId, TCommand command, TData data, CommandResult result)
           => logger.LogInformation("{CommandName} with Id: {@CommandId} finished with {@CommandResult} and {@CommandData} in {FinishDateTime}", command.GetType().Name, commandId, result, data, DateTime.UtcNow);


    }
}
