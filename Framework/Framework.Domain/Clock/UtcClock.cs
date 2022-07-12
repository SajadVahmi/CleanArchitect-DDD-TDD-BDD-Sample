using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Domain.Clock
{
    public class UtcClock : IClock
    {
        public DateTime Now()
        {
            return DateTime.UtcNow;
        }
    }
}
