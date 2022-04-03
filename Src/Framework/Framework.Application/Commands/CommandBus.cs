using Framework.Domain.Commands;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Application.Commands
{
    public class CommandBus : ICommandBus
    {
        private readonly IServiceProvider serviceProvider;

        public CommandBus(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public Task<CommandResult> Send<TCommand>(TCommand command) where TCommand : class, ICommand
        {
            var handler = serviceProvider.GetRequiredService<ICommandHandler<TCommand>>();
            return handler.Handle(command);

        }

        public Task<CommandResult<TData>> Send<TCommand, TData>(TCommand command) where TCommand : class, ICommand<TData>
        {
            var handler = serviceProvider.GetRequiredService<ICommandHandler<TCommand, TData>>();
            return handler.Handle(command);
        }

    }
}
