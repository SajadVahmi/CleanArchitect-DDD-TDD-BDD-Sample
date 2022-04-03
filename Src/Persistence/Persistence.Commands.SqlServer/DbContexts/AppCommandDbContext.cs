using Domain.Models.Customers;
using Framework.Persistence.DbContexts;
using Framework.Persistence.Extensions;
using Microsoft.EntityFrameworkCore;
using Persistence.Commands.SqlServer.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Commands.SqlServer.DbContexts
{
    public class AppCommandDbContext : CommandDbContext
    {
        public const string SCHEMA = "dbo";
        public AppCommandDbContext(DbContextOptions<AppCommandDbContext> options) : base(options)
        {
        }


        public override string DefineSchema()
        {
            return SCHEMA;
        }

        public DbSet<Customer> Customers { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
            modelBuilder.UseValueConverter(new CustomerIdValueConverter());

        }
    }
}
