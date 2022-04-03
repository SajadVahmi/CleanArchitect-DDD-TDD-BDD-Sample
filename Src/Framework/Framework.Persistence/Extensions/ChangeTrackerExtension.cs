using Framework.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Persistence.Extensions
{
    public static class ChangeTrackerExtension
    {
        public static List<IAggregateRoot> GetAggregatesWithEvent(this ChangeTracker changeTracker) =>
           changeTracker.Entries<IAggregateRoot>()
                                    .Where(x => x.State != EntityState.Detached).Select(c => c.Entity).Where(c => c.DomainEvents.Any()).ToList();
    }
}
