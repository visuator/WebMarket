using Microsoft.EntityFrameworkCore;

using ProductService.Entities;

using System.Linq.Expressions;
using System.Reflection;

namespace ProductService.Storages
{
    public class ProductDbContext : DbContext
    {
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assembly = Assembly.Load("ProductService");
            var baseEntities = assembly.DefinedTypes.Where(x => x.BaseType is not null && x.BaseType == typeof(BaseEntity));
            Expression<Func<BaseEntity, bool>> predicate = (be) => !be.IsDeleted;
            foreach (var be in baseEntities)
                modelBuilder.Entity(be, x => x.HasQueryFilter(predicate));
            base.OnModelCreating(modelBuilder);
        }
    }
}
