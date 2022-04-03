using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Domain.Commands
{
    public interface ICommandBus
    {
        Task<CommandResult> Send<TCommand>(TCommand command) where TCommand : class, ICommand;
        Task<CommandResult<TData>> Send<TCommand, TData>(TCommand command) where TCommand : class, ICommand<TData>;

    }
}
