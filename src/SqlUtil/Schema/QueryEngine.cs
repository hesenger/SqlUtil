using System.Linq.Expressions;

namespace SqlUtil.Schema;

public class QueryEngine
{
    public QueryEngine(Database database, Type from)
    {
        Database = database;
        From = from;
        Joins = new List<QueryJoin>();
    }

    public virtual Database Database { get; set; }

    public virtual Type From { get; set; }

    public virtual IList<QueryJoin> Joins { get; private set; }

    public virtual void AddJoin<TSource, TProperty>(
        QueryJoinKind kind,
        Expression<Func<TSource, TProperty>> expression)
    {
        Joins.Add(new QueryJoin(
            Database,
            kind,
            Database.PropertyReader.GetPropertyInfo(expression)));
    }

    public virtual void AddJoin<TSource, TSource1, TProperty>(
    QueryJoinKind kind,
    Expression<Func<TSource, TSource1, TProperty>> expression)
    {
        Joins.Add(new QueryJoin(
            Database,
            kind,
            Database.PropertyReader.GetPropertyInfo(expression)));
    }

    public virtual IList<T> Execute<T>()
    {
        return new List<T>();
    }
}