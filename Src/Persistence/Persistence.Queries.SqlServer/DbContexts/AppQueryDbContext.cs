using Domain.Models.Customers;
using Framework.Persistence.DbContexts;
using Microsoft.EntityFrameworkCore;
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



        public DbSet<CustomerReadModel> Customers { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);

        }
    }
}
