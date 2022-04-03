using Domain.Models.Customers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Persistence.Commands.SqlServer.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Commands.SqlServer.Configurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable(nameof(Customer), AppCommandDbContext.SCHEMA);
            builder.Property(e => e.Id).ValueGeneratedNever();

            builder.OwnsOne(e => e.Name, map =>
            {

                map.Property(v => v.Firstname)
                .HasColumnName("Firstname")
                .HasColumnType("varchar(60)");

                map.Property(v => v.Lastname)
                .HasColumnName("Lastname")
                .HasColumnType("varchar(60)"); ;
            });

         

            builder.OwnsOne(e => e.Email, map =>
            {
                map.HasIndex(b => b.Value)
                   .IsUnique();
                map.Property(v => v.Value)
                .HasColumnName("Email")
                .HasColumnType("varchar(60)");

            });
        }
    }

    public class CustomerIdValueConverter : ValueConverter<CustomerId, Guid>
    {
        public CustomerIdValueConverter(ConverterMappingHints mappingHints = default)
            : base(MapTo, MapFrom, mappingHints)
        {

        }

        static Expression<Func<CustomerId, Guid>> MapTo => e => e.Value;
        static Expression<Func<Guid, CustomerId>> MapFrom = e => CustomerId.FromGuid(e);
    }
}
