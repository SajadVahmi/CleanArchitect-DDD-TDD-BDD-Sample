using Framework.Domain.Clock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.TestTools
{
    public class ClockStub : IClock
    {
        private DateTime now;
        public ClockStub()
        {
            now = DateTime.UtcNow;
        }
        public DateTime Now()
        {
            return now;
        }

        public void TimeTravelTo(DateTime dateTime) => now = dateTime;
    }
}
