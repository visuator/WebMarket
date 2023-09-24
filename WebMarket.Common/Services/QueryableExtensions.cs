using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

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
