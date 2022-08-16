using System.Reflection;

namespace SqlUtil.Schema;

public class QueryJoin
{
    public QueryJoin(
        Database database,
        QueryJoinKind kind,
        PropertyInfo referenceProperty)
    {
        Database = database;
        Kind = kind;
        ReferenceProperty = referenceProperty;
    }

    public Database Database { get; private set; }

    public virtual QueryJoinKind Kind { get; set; }

    public virtual PropertyInfo ReferenceProperty { get; set; }
}
