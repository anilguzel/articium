using System.Linq.Expressions;
using System.Reflection;
using LinqKit;

public class QueryBuilder<T>
{
    public Expression<Func<T, bool>> BuildQuery(Dictionary<string, string> filters)
    {
        var predicate = PredicateBuilder.New<T>(true);

        foreach (var filter in filters)
        {
            var propertyName = filter.Key;
            var propertyValue = filter.Value;

            var property = typeof(T).GetProperty(propertyName, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
            if (property == null)
            {
                throw new ArgumentException($"Property '{propertyName}' does not exist on type '{typeof(T).Name}'.");
            }

            var parameter = Expression.Parameter(typeof(T), "x");
            var propertyAccess = Expression.Property(parameter, propertyName);
            var propertyType = property.PropertyType;

            object value;
            if (propertyType == typeof(Guid))
            {
                if (!Guid.TryParse(propertyValue, out Guid guidValue))
                {
                    throw new ArgumentException($"Invalid GUID format for property '{propertyName}'.");
                }
                value = guidValue;
            }
            else
            {
                value = Convert.ChangeType(propertyValue, propertyType);
            }
            
            var constant = Expression.Constant(propertyValue);
            var body = Expression.Equal(propertyAccess, constant);

            var lambda = Expression.Lambda<Func<T, bool>>(body, parameter);
            predicate = predicate.And(lambda);
        }

        return predicate;
    }
}
