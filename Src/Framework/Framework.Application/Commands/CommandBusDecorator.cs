using Framework.Domain.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Application.Commands
{
    public abstract class CommandBusDecorator : ICommandBus
    {
        protected ICommandBus commandBus;
        public CommandBusDecorator(ICommandBus commandBus)
        {
            this.commandBus = commandBus;
        }
        public abstract Task<CommandResult> Send<TCommand>(TCommand command) where TCommand : class, ICommand;

        public abstract Task<CommandResult<TData>> Send<TCommand, TData>(TCommand command) where TCommand : class, ICommand<TData>;
    }
}
