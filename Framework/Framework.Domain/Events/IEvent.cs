using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Domain.Events
{
    public interface IEvent
    {
        Guid EventId { get; }
        DateTime PublishDateTime { get; }

    }
}
