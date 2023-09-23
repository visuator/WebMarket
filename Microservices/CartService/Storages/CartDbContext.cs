using CartService.Entities;

using Microsoft.EntityFrameworkCore;

using System.Linq.Expressions;
using System.Reflection;

using WebMarket.Common.Services;

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
            modelBuilder.ApplyQueryFilters(Assembly.GetExecutingAssembly());
            modelBuilder.Entity<UserProduct>().HasKey(x => new { x.UserId, x.ProductId });
            base.OnModelCreating(modelBuilder);
        }
    }
}
