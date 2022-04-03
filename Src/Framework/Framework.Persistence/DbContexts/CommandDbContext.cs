using Framework.Domain.Services;
using Framework.Persistence.Configurations;
using Framework.Persistence.Extensions;
using Framework.Persistence.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Framework.Persistence.DbContexts
{
    public abstract class CommandDbContext : DbContext
    {
        public CommandDbContext(DbContextOptions options)
            : base(options)
        {

        }
        public string Schema { get; protected set; }
        public DbSet<OutboxItem> OutboxItems { get; set; }
        public abstract string DefineSchema();

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new OutboxItemConfiguration(Schema));
        }

        public override int SaveChanges()
        {
            ChangeTracker.DetectChanges();
            beforeSaveTriggers();
            ChangeTracker.AutoDetectChangesEnabled = false;
            var result = base.SaveChanges();
            ChangeTracker.AutoDetectChangesEnabled = true;
            return result;

        }
        public override Task<int> SaveChangesAsync(
         bool acceptAllChangesOnSuccess,
         CancellationToken cancellationToken = default)
        {
            ChangeTracker.DetectChanges();
            beforeSaveTriggers();
            ChangeTracker.AutoDetectChangesEnabled = false;
            var result = base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
            ChangeTracker.AutoDetectChangesEnabled = true;
            return result;
        }



        private void beforeSaveTriggers()
        {
            addOutboxEvetItems();
        }

        private void addOutboxEvetItems()
        {
            var changedAggregates = ChangeTracker.GetAggregatesWithEvent();
            var userInfoService = this.GetService<IUserInfoService>();
            var jsonSerializer = this.GetService<IJsonSerializer>();

            foreach (var aggregate in changedAggregates)
            {
                var events = aggregate.DomainEvents.OrderBy(e => e.PublishDateTime);
                foreach (var @event in events)
                {
                    var outboxItem = new OutboxItem();
                    outboxItem.EventId = @event.EventId;
                    outboxItem.AccuredByUserId = userInfoService.GetSub();
                    outboxItem.AccuredOn = @event.PublishDateTime;
                    outboxItem.EventName = @event.GetType().Name;
                    outboxItem.EventTypeName = @event.GetType().FullName;
                    outboxItem.EventBody = jsonSerializer.Serilize(@event);
                    outboxItem.Processed = false;
                    OutboxItems.Add(outboxItem);
                }
                aggregate.ClearEvents();
            }
        }



    }
}
