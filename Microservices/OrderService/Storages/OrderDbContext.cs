using Microsoft.EntityFrameworkCore;

using OrderService.Entities;

using System.Linq.Expressions;
using System.Reflection;

namespace OrderService.Storages
{
    public class OrderDbContext : DbContext
    {
        public OrderDbContext(DbContextOptions<OrderDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<OrderProduct> OrderProducts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assembly = Assembly.Load("OrderService");
            var baseEntities = assembly.DefinedTypes.Where(x => x.BaseType is not null && x.BaseType == typeof(BaseEntity));
            Expression<Func<BaseEntity, bool>> predicate = (be) => !be.IsDeleted;
            foreach (var be in baseEntities)
                modelBuilder.Entity(be, x => x.HasQueryFilter(predicate));
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<OrderProduct>().HasKey(x => new { x.OrderId, x.ProductId });
        }
    }
}
