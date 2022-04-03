using Domain.Models.Customers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.Queries.SqlServer.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Queries.SqlServer.Configurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<CustomerReadModel>
    {
        public void Configure(EntityTypeBuilder<CustomerReadModel> builder)
        {
            builder.ToTable(nameof(Customer), AppQueryDbContext.SCHEMA);
            builder.Property(e => e.Id).ValueGeneratedNever();
            builder.Property(e => e.Firstname).HasColumnType("varchar(60)");
            builder.Property(e => e.Lastname).HasColumnType("varchar(60)");
            builder.Property(e => e.PhoneNumber).HasColumnType("varchar(60)");
            builder.Property(e => e.Email).HasColumnType("varchar(60)");
            builder.Property(e => e.BankAccountNumber).HasColumnType("varchar(60)");
            builder.HasIndex(b => b.Email)
                   .IsUnique();

        }
    }
}
