using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

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
            var incomingMigrations = await dbContext.Database.GetPendingMigrationsAsync(token);
            if (incomingMigrations.Any())
                await dbContext.Database.MigrateAsync(token);
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
