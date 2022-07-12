using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Domain.Events
{
    public class DomainEvent : IDomainEvent
    {
        public Guid EventId { get; private set; } = Guid.NewGuid();
        public DateTime PublishDateTime { get; private set; } = DateTime.UtcNow;

    }
}
