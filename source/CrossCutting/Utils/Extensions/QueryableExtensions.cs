using System;
using System.Linq;
using System.Linq.Expressions;

namespace Solution.CrossCutting.Utils
{
    public static class QueryableExtensions
    {
        public static IQueryable<T> Order<T>(this IQueryable<T> queryable, string property, bool isAscending)
        {
            if (queryable?.Any() != true || string.IsNullOrEmpty(property))
            {
                return queryable;
            }

            var expression = CreateExpression(typeof(T), property);

            return isAscending ? Queryable.OrderBy(queryable, expression) : Queryable.OrderByDescending(queryable, expression);
        }

        public static IQueryable<T> Page<T>(this IQueryable<T> queryable, int index, short size)
        {
            if (queryable?.Any() != true || index == 0 || size == 0)
            {
                return queryable;
            }

            return queryable.Skip((index - 1) * size).Take(size);
        }

        private static dynamic CreateExpression(Type type, string property)
        {
            var parameter = Expression.Parameter(type, "x");

            Expression body = parameter;

            property.Split('.').ToList().ForEach(member => body = Expression.PropertyOrField(body, member));

            return Expression.Lambda(body, parameter);
        }
    }
}
