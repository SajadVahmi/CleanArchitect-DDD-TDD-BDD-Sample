using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.Queries.SqlServer.DbContexts;
using Persistence.Queries.SqlServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Queries.SqlServer.Configurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable(nameof(Customer), AppQueryDbContext.SCHEMA);
            builder.Property(e => e.Id).ValueGeneratedNever();
            builder.Property(e => e.Firstname).HasColumnType("varchar(60)");
            builder.Property(e => e.Lastname).HasColumnType("varchar(60)");
            builder.Property(e => e.Email).HasColumnType("varchar(60)");
            builder.HasIndex(b => b.Email)
                   .IsUnique();

        }
    }
}
