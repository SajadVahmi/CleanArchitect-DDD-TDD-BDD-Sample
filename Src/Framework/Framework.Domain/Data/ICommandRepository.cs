using Framework.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Domain.Data
{
    public interface ICommandRepository<TEntity, TKey> : IUnitOfWork
       where TEntity : AggregateRoot<TKey>
    {

    }
}
