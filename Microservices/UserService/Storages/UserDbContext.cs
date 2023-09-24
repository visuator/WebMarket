using Microsoft.EntityFrameworkCore;

using System.Reflection;

using UserService.Entities;

using WebMarket.Common.Services;

namespace UserService.Storages
{
    public class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Database.MigrateAsync();
            modelBuilder.ApplyQueryFilters(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
    }
}
