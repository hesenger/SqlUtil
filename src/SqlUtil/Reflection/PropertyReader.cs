using System.Linq.Expressions;
using System.Reflection;

namespace SqlUtil.Reflections;

public class PropertyReader
{
    public virtual PropertyInfo GetPropertyInfo<TSource, TProperty>(
        Expression<Func<TSource, TProperty>> expression)
    {
        ArgumentNullException.ThrowIfNull(
            expression,
            nameof(expression));

        if (expression.Body is MemberExpression member)
        {
            if (member.Member is PropertyInfo property)
            {
                return property;
            }
        }

        throw new ArgumentException(
            "Expression is not a member access",
            nameof(expression));
    }

    public virtual PropertyInfo GetPropertyInfo<TSource, TSource2, TProperty>(
    Expression<Func<TSource, TSource2, TProperty>> expression)
    {
        ArgumentNullException.ThrowIfNull(
            expression,
            nameof(expression));

        if (expression.Body is MemberExpression member)
        {
            if (member.Member is PropertyInfo property)
            {
                return property;
            }
        }

        throw new ArgumentException(
            "Expression is not a member access",
            nameof(expression));
    }
}