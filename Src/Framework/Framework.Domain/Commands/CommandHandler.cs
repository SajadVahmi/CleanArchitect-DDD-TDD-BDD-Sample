using Framework.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Domain.Commands
{
    public abstract class CommandHandler<TCommand, TData> : ICommandHandler<TCommand, TData>
    where TCommand : ICommand<TData>
    {
        protected readonly CommandResult<TData> result = new CommandResult<TData>();

        public abstract Task<CommandResult<TData>> Handle(TCommand command);
        protected virtual Task<CommandResult<TData>> OkAsync(TData data)
        {
            result.data = data;
            result.Status = ResultStatus.Ok;
            return Task.FromResult(result);
        }
        protected virtual CommandResult<TData> Ok(TData data)
        {
            result.data = data;
            result.Status = ResultStatus.Ok;
            return result;
        }
        protected virtual Task<CommandResult<TData>> FailAsync(ResultStatus status)
        {
            result.Status = ResultStatus.Ok;
            return Task.FromResult(result);
        }
        protected virtual CommandResult<TData> Fail(ResultStatus status)
        {
            result.Status = ResultStatus.Ok;
            return result;
        }
        protected virtual Task<CommandResult<TData>> ResultAsync(TData data, ResultStatus status)
        {
            result.data = data;
            result.Status = status;
            return Task.FromResult(result);
        }
        protected virtual CommandResult<TData> Result(TData data, ResultStatus status)
        {
            result.data = data;
            result.Status = status;
            return result;
        }
        protected void AddError(string error)
        {
            result.AddError(error);
        }

    }

    public abstract class CommandHandler<TCommand> : ICommandHandler<TCommand>
    where TCommand : ICommand
    {

        protected readonly CommandResult result = new();
        public abstract Task<CommandResult> Handle(TCommand command);

        protected virtual Task<CommandResult> OkAsync()
        {
            result.Status = ResultStatus.Ok;
            return Task.FromResult(result);
        }

        protected virtual CommandResult Ok()
        {
            result.Status = ResultStatus.Ok;
            return result;
        }

        protected virtual Task<CommandResult> FailAsync(ResultStatus resultStatus)
        {
            result.Status = resultStatus;
            return Task.FromResult(result);
        }
        protected virtual CommandResult Fail(ResultStatus resultStatus)
        {
            result.Status = ResultStatus.Ok;
            return result;
        }

        protected virtual Task<CommandResult> ResultAsync(ResultStatus status)
        {
            result.Status = status;
            return Task.FromResult(result);
        }
        protected virtual CommandResult Result(ResultStatus status)
        {
            result.Status = status;
            return result;
        }
        protected virtual Task<CommandResult> NotFoundAsync()
        {
            result.Status = ResultStatus.NotFound;
            return Task.FromResult(result);
        }
        protected virtual CommandResult NotFound()
        {
            result.Status = ResultStatus.NotFound;
            return result;
        }
        protected void AddError(string error)
        {
            result.AddError(error);
        }

    }
}
