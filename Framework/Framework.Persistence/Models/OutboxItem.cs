using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Persistence.Models
{
    public class OutboxItem
    {
        public long Id { get; set; }
        public Guid EventId { get; set; }
        public string AccuredByUserId { get; set; }
        public DateTime AccuredOn { get; set; }
        public string EventName { get; set; }
        public string EventTypeName { get; set; }
        public string EventBody { get; set; }
        public bool Processed { get; set; }

    }
}
