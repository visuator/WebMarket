using CartService.Entities;

using Microsoft.EntityFrameworkCore;

using System.Linq.Expressions;
using System.Reflection;

namespace CartService.Storages
{
    public class CartDbContext : DbContext
    {
        public CartDbContext(DbContextOptions<CartDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<UserProduct> UserProducts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assembly = Assembly.Load("CartService");
            var baseEntities = assembly.DefinedTypes.Where(x => x.BaseType is not null && x.BaseType == typeof(BaseEntity));
            Expression<Func<BaseEntity, bool>> predicate = (be) => !be.IsDeleted;
            foreach (var be in baseEntities)
                modelBuilder.Entity(be, x => x.HasQueryFilter(predicate));
            base.OnModelCreating(modelBuilder);
        }
    }
}
