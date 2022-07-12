using Framework.Application.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Application.Commands
{
    public interface ICommandBus
    {
        Task<Result> SendAsync<TCommand>(TCommand command) where TCommand : class, ICommand;
        Task<Result<TData>> SendAsync<TCommand, TData>(TCommand command) where TCommand : class, ICommand<TData>;

    }
}
