using Framework.Application.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Application.Commands
{
    public abstract class CommandHandler<TCommand, TData> : ICommandHandler<TCommand, TData>
    where TCommand : ICommand<TData>
    {
        protected readonly Result<TData> result = new Result<TData>();

        public abstract Task<Result<TData>> Handle(TCommand command);
        protected virtual Task<Result<TData>> OkAsync(TData data)
        {
            result.data = data;
            result.Status = ResultStatus.Ok;
            return Task.FromResult(result);
        }
        protected virtual Result<TData> Ok(TData data)
        {
            result.data = data;
            result.Status = ResultStatus.Ok;
            return result;
        }
        protected virtual Task<Result<TData>> FailAsync(ResultStatus status)
        {
            result.Status = ResultStatus.Ok;
            return Task.FromResult(result);
        }
        protected virtual Result<TData> Fail(ResultStatus status)
        {
            result.Status = ResultStatus.Ok;
            return result;
        }
        protected virtual Task<Result<TData>> ResultAsync(TData data, ResultStatus status)
        {
            result.data = data;
            result.Status = status;
            return Task.FromResult(result);
        }
        protected virtual Result<TData> Result(TData data, ResultStatus status)
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

        protected readonly Result result = new();
        public abstract Task<Result> Handle(TCommand command);

        protected virtual Task<Result> OkAsync()
        {
            result.Status = ResultStatus.Ok;
            return Task.FromResult(result);
        }

        protected virtual Result Ok()
        {
            result.Status = ResultStatus.Ok;
            return result;
        }

        protected virtual Task<Result> FailAsync(ResultStatus resultStatus)
        {
            result.Status = resultStatus;
            return Task.FromResult(result);
        }
        protected virtual Result Fail(ResultStatus resultStatus)
        {
            result.Status = ResultStatus.Ok;
            return result;
        }

        protected virtual Task<Result> ResultAsync(ResultStatus status)
        {
            result.Status = status;
            return Task.FromResult(result);
        }
        protected virtual Result Result(ResultStatus status)
        {
            result.Status = status;
            return result;
        }
        protected virtual Task<Result> NotFoundAsync()
        {
            result.Status = ResultStatus.NotFound;
            return Task.FromResult(result);
        }
        protected virtual Result NotFound()
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
