using System.Linq.Expressions;
using System.Reflection;

namespace Housing.Application.Common.Models;

public class QueryBuilder<T> : IQueryBuilder<T>
{
    public IQueryable<T> BuildSortingQuery(IQueryable<T> source, string attribute, bool ascending)
    {
        if (IsValidProperty(attribute))
        {
            return ascending 
                ? ApplyOrder(source, attribute, "OrderBy") 
                : ApplyOrder(source, attribute, "OrderByDescending");
        }

        return source;
    }

    private static bool IsValidProperty(string propertyName)
    {
        return typeof(T).GetProperty(propertyName, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance) != null;
    }

    private static IQueryable<T> ApplyOrder(IQueryable<T> source, string propertyName, string methodName)
    {
        var type = typeof(T);
        
        var property = type.GetProperty(propertyName, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance)!;
        var parameter = Expression.Parameter(type, "p");
        
        var propertyAccess = Expression.MakeMemberAccess(parameter, property);
        var orderByExpression = Expression.Lambda(propertyAccess, parameter);

        var resultExpression = Expression.Call(typeof(Queryable), methodName, new Type[] { type, property.PropertyType }, source.Expression, Expression.Quote(orderByExpression));
        return source.Provider.CreateQuery<T>(resultExpression);
    }
}