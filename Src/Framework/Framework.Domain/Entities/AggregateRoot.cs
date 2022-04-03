using Framework.Domain.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Domain.Entities
{
    public class AggregateRoot<TKEY> : Entity<TKEY>, IAggregateRoot
    {
        protected readonly List<IDomainEvent> _events = new List<IDomainEvent>();

        protected void AddDomainEvent(IDomainEvent @event) => _events.Add(@event);
        protected void RemoveDomainEvent(IDomainEvent @event) => _events.Remove(@event);
        protected void ClearDomainEvents() => _events.Clear();

        public IReadOnlyCollection<IDomainEvent> DomainEvents =>
         _events.AsReadOnly();
        public void ClearEvents() => _events.Clear();
    }
}
