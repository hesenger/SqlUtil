using System.Linq.Expressions;
using SqlUtil.Schema;

namespace SqlUtil;

public class JoinedQueryBuilder<TFrom, TJoin1>
    where TFrom : class
    where TJoin1 : class
{
    public JoinedQueryBuilder(QueryEngine queryEngine)
    {
        QueryEngine = queryEngine;
    }

    protected virtual QueryEngine QueryEngine { get; set; }

    public virtual JoinedQueryBuilder<TFrom, TJoin1, TJoin2> LeftJoin<TJoin2>(
        Expression<Func<TFrom, TJoin1, TJoin2?>> joinProperty)
        where TJoin2 : class
    {
        QueryEngine.AddJoin(
            QueryJoinKind.LeftJoin,
            joinProperty);
        return new JoinedQueryBuilder<TFrom, TJoin1, TJoin2>(QueryEngine);
    }

    public virtual JoinedQueryBuilder<TFrom, TJoin1, TJoin2> RightJoin<TJoin2>(
        Expression<Func<TFrom, TJoin1, TJoin2?>> joinProperty)
        where TJoin2 : class
    {
        QueryEngine.AddJoin(
            QueryJoinKind.RightJoin,
            joinProperty);
        return new JoinedQueryBuilder<TFrom, TJoin1, TJoin2>(QueryEngine);
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

public class JoinedQueryBuilder<TFrom, TJoin1, TJoin2>
    where TFrom : class
    where TJoin1 : class
    where TJoin2 : class
{
    public JoinedQueryBuilder(QueryEngine queryEngine)
    {
        QueryEngine = queryEngine;
    }

    protected virtual QueryEngine QueryEngine { get; set; }

    public virtual IList<TFrom> All()
    {
        return QueryEngine.Execute<TFrom>();
    }

    public virtual TFrom? First()
    {
        return QueryEngine.Execute<TFrom>().FirstOrDefault();
    }
}