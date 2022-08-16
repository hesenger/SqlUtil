using System.Linq.Expressions;
using SqlUtil.Schema;

namespace SqlUtil;

public class QueryBuilder<TFrom> where TFrom : class
{
    public QueryBuilder(Database database,
        QueryEngine queryEngine)
    {
        Database = database;
        QueryEngine = queryEngine;
    }

    protected virtual Database Database { get; set; }

    protected virtual QueryEngine QueryEngine { get; set; }

    public virtual JoinedQueryBuilder<TFrom, TJoin1> LeftJoin<TJoin1>(
        Expression<Func<TFrom, TJoin1?>> joinProperty)
        where TJoin1 : class
    {
        QueryEngine.AddJoin(
            QueryJoinKind.LeftJoin,
            joinProperty);
        return new JoinedQueryBuilder<TFrom, TJoin1>(QueryEngine);
    }

    public virtual JoinedQueryBuilder<TFrom, TJoin1> RightJoin<TJoin1>(
        Expression<Func<TFrom, TJoin1?>> joinProperty)
        where TJoin1 : class
    {
        QueryEngine.AddJoin(
            QueryJoinKind.RightJoin,
            joinProperty);
        return new JoinedQueryBuilder<TFrom, TJoin1>(QueryEngine);
    }

    public virtual IList<TFrom> All()
    {
        return QueryEngine.Execute<TFrom>();
    }

    public virtual TFrom? First()
    {
        return QueryEngine.Execute<TFrom>().FirstOrDefault();
    }
}
