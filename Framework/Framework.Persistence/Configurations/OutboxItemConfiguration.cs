using Framework.Persistence.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Persistence.Configurations
{
    public class OutboxItemConfiguration : IEntityTypeConfiguration<OutboxItem>
    {
        private string schema = string.Empty;

        public OutboxItemConfiguration(string schema)
        {
            this.schema = schema;
        }
        public void Configure(EntityTypeBuilder<OutboxItem> builder)
        {
            if (!string.IsNullOrEmpty(this.schema))
                builder.ToTable(nameof(OutboxItem), this.schema);
            else
                builder.ToTable(nameof(OutboxItem));
            builder.HasKey(c => c.Id);
            builder.Property(c => c.AccuredByUserId).HasMaxLength(255);
            builder.Property(c => c.EventName).HasMaxLength(255);
            builder.Property(c => c.EventTypeName).HasMaxLength(500);
        }
    }
}
