using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Domain.Exceptions
{
    public class DomainException : Exception
    {
        protected DomainException()
        {
        }

        public DomainException(int code, string message):base(message)
        {
            this.ErrorCode = code;
            this.ExceptionMessage = message;
          
        }
        public int ErrorCode { get; private set; }

        public string ExceptionMessage { get; private set; }

    }


}
