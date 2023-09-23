using Microsoft.EntityFrameworkCore;

using System.Linq.Expressions;
using System.Reflection;

using UserService.Entities;

namespace UserService.Storages
{
    public class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options) { }
        
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assembly = Assembly.Load("UserService");
            var baseEntities = assembly.DefinedTypes.Where(x => x.BaseType is not null && x.BaseType == typeof(BaseEntity));
            Expression<Func<BaseEntity, bool>> predicate = (be) => !be.IsDeleted;
            foreach (var be in baseEntities)
                modelBuilder.Entity(be, x => x.HasQueryFilter(predicate));
            base.OnModelCreating(modelBuilder);
        }
    }
}
