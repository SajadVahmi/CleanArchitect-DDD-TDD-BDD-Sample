using Framework.Application.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Framework.Application.Commands
{
    public interface ICommandHandler<TCommand, TData> where TCommand : ICommand<TData>
    {
        Task<Result<TData>> HandleAsync(TCommand command, CancellationToken cancellationToken = default);
    }
    public interface ICommandHandler<TCommand> where TCommand : ICommand
    {
        Task<Result> HandleAsync(TCommand command, CancellationToken cancellationToken = default);
    }
}
