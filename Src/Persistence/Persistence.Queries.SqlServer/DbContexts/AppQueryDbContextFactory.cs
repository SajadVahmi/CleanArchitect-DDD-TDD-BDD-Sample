using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Queries.SqlServer.DbContexts
{
    public class AppQueryDbContextFactory : IDesignTimeDbContextFactory<AppQueryDbContext>
    {
        public AppQueryDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppQueryDbContext>();
            optionsBuilder.UseSqlServer("Server=.;Database=AppCommandDb;Integrated Security=true;");
            return new AppQueryDbContext(optionsBuilder.Options);
        }
    }
}
