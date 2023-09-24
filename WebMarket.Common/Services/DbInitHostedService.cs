using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebMarket.Common.Services
{
    public class DbInitHostedService<TDbContext> : IHostedService where TDbContext : DbContext
    {
        private readonly IServiceScopeFactory _factory;

        public DbInitHostedService(IServiceScopeFactory factory)
        {
            _factory = factory;
        }

        public async Task StartAsync(CancellationToken token)
        {
            await using var scope = _factory.CreateAsyncScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<TDbContext>();
            var logger = scope.ServiceProvider.GetRequiredService<ILogger<DbInitHostedService<TDbContext>>>();
            var semaphore = new SemaphoreSlim(1, 1);
            await semaphore.WaitAsync(token);
            try
            {
                var incomingMigrations = await dbContext.Database.GetPendingMigrationsAsync(token);
                if (incomingMigrations.Any())
                    await dbContext.Database.MigrateAsync(token);
            }
            catch(Exception e) { logger.LogError("Db migration fault: {exception}", e.Message); }
            semaphore.Release();
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
