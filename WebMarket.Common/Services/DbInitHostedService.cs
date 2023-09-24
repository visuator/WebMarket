using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using Polly;

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

            using var semaphore = new SemaphoreSlim(1, 1);
            await semaphore.WaitAsync(token);

            logger.LogInformation("DbContext entry: {name}", typeof(TDbContext).Name);
            await Policy.Handle<Exception>().WaitAndRetryForeverAsync((i) => TimeSpan.FromMilliseconds(i + 350)).ExecuteAsync(async () =>
            {
                await dbContext.Database.MigrateAsync(token);
            });

            semaphore.Release();
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
