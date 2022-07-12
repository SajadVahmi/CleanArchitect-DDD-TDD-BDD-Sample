using Framework.Domain.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Domain.Entities
{
    public interface IAggregateRoot
    {
        public IReadOnlyCollection<IDomainEvent> DomainEvents { get; }
        public void ClearEvents();
    }
}
