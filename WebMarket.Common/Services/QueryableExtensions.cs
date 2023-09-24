using System.Linq.Expressions;

using WebMarket.Common.Messages;

namespace WebMarket.Common.Services
{
    public static class QueryableExtensions
    {
        public static IQueryable<T> ApplyOrdering<T, TProperty>(this IQueryable<T> query, Expression<Func<T, TProperty>> property, ISupportOrdering obj)
        {
            if (obj.Descending)
                return query.OrderByDescending(property);
            return query;
        }
    }
}
