using Framework.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Domain.Commands
{
    public class CommandResult : Result
    {

    }

    public class CommandResult<TData> : CommandResult
    {
        internal TData data;
        public TData Data
        {
            get
            {
                return data;
            }
        }

    }
}
