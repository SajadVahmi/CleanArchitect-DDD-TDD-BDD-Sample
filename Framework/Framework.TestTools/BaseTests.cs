using Framework.Domain.Clock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.TestTools
{
    public class BaseTests
    {
        public IClock Clock { get; set; }
        public BaseTests()
        {
            Clock = new ClockStub();
        }
    }
}
