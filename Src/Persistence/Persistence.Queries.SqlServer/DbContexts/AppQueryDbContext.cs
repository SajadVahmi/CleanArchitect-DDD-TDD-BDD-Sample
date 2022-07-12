
using Framework.Persistence.DbContexts;
using Microsoft.EntityFrameworkCore;
using Persistence.Queries.SqlServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Queries.SqlServer.DbContexts
{
    public class AppQueryDbContext : QueryDbContext
    {


        public const string SCHEMA = "dbo";
        public AppQueryDbContext(DbContextOptions<AppQueryDbContext> options) : base(options)
        {
        }



        public DbSet<Customer> Customers { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);

        }
    }
}
