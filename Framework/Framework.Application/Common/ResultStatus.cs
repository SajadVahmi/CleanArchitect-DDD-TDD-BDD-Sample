using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Application.Common
{
    public enum ResultStatus
    {
        Ok = 1,
        NotFound = 2,
        ValidationError = 3,
        DomainException = 4,
        Exception = 5,
    }
}
