namespace SqlUtil;

public class QueryBuilder<T> where T : class
{
    public QueryBuilder(Database database)
    {
        Database = database;
    }

    public virtual Database Database { get; set; }

    public virtual QueryBuilder<T> Join()
    {
        return this;
    }

    public virtual QueryBuilder<T> LeftJoin()
    {
        return this;
    }

    public virtual QueryBuilder<T> RightJoin()
    {
        return this;
    }

    public virtual IList<T> All()
    {
        return new List<T>();
    }

    public virtual T? First()
    {
        return null;
    }
}
