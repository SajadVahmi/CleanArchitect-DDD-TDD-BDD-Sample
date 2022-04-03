using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.RestApi.Integration.Common
    .DbConnections
{
    public static class DbTestConnections
    {
        public static string COMMAND_DBCONTEXT => "Server=.;Database=AppCommandDb;Integrated Security=true;";
    }
}
