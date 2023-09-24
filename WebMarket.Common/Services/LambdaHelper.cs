using Microsoft.EntityFrameworkCore;

using System.Linq.Expressions;
using System.Reflection;

using WebMarket.Common.Entities;

namespace WebMarket.Common.Services
{
    public static class LambdaHelper
    {
        public static void ApplyQueryFilters(this ModelBuilder modelBuilder, Assembly assembly)
        {
            var baseEntities = assembly.DefinedTypes.Where(x => x.BaseType is not null && x.BaseType == typeof(BaseEntity));
            foreach (var be in baseEntities)
            {
                var p = Expression.Parameter(be, "be");
                var expression = Expression.Lambda(
                    Expression.Not(Expression.Property(p, "IsDeleted")), p);
                modelBuilder.Entity(be).HasQueryFilter(expression);
            }
        }
    }
}
