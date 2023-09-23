using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Diagnostics;

using WebMarket.Common.Entities;

namespace WebMarket.Common.Services
{
    public class EntityInterceptor : SaveChangesInterceptor
    {
        public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
        {
            BaseSavingChanges(eventData.Context!.ChangeTracker.Entries());
            return base.SavingChanges(eventData, result);
        }
        public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
        {
            BaseSavingChanges(eventData.Context!.ChangeTracker.Entries());
            return base.SavingChangesAsync(eventData, result, cancellationToken);
        }

        private static void BaseSavingChanges(IEnumerable<EntityEntry> entries)
        {
            var now = DateTime.UtcNow;
            foreach (var entry in entries)
            {
                if (entry.Entity is not BaseEntity be) continue;
                if (entry.State == EntityState.Added)
                    be.CreatedAt = now;
                be.UpdatedAt = now;
            }
        }
    }
}
