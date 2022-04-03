using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Commands.SqlServer.DbContexts
{
    public class AppCommandDbContextFactory : IDesignTimeDbContextFactory<AppCommandDbContext>
    {
        public AppCommandDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppCommandDbContext>();
            optionsBuilder.UseSqlServer("Server=.;Database=AppCommandDb;Integrated Security=true;");
            return new AppCommandDbContext(optionsBuilder.Options);
        }
    }
}
