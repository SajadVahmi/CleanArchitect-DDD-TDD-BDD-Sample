using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Domain.Exceptions
{
    public class AppArgumentException : AppException
    {
        public AppArgumentException(string message) : base(message)
        {
        }

        public AppArgumentException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
