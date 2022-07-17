using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Framework.Application.Queries
{
    public interface IQueryBus
    {
        Task<T> ExecuteAsync<T>(IQuery query, CancellationToken cancellationToken = default);
    }

    public sealed class QueryBus : IQueryBus
    {
        private readonly IServiceProvider _provider;

        public QueryBus(IServiceProvider provider)
        {
            _provider = provider;
        }

        public async Task<T> ExecuteAsync<T>(IQuery query, CancellationToken cancellationToken = default)
        {
            Type type = typeof(IQueryHandler<,>);
            Type[] typeArgs = { query.GetType(), typeof(T) };
            Type handlerType = type.MakeGenericType(typeArgs);
            dynamic handler = _provider.GetService(handlerType);
            T result = await handler.HandleAsync((dynamic)query, cancellationToken);
            return result;
        }
    }
}
