using SqlUtil.Reflections;
using SqlUtil.Schema;

[assembly: CLSCompliant(true)]
namespace SqlUtil;

public class Database
{
    public Database(
        string connectionString,
        INamingConvention? namingConvention = null,
        PropertyReader? propertyReader = null)
    {
        ConnectionString = connectionString;
        NamingConvention = namingConvention ?? new DefaultNamingConvention();
        PropertyReader = propertyReader ?? new PropertyReader();
    }

    public virtual string ConnectionString { get; set; }

    public virtual INamingConvention NamingConvention { get; set; }

    public virtual PropertyReader PropertyReader { get; private set; }

    public virtual QueryBuilder<T> From<T>() where T : class
    {
        return new QueryBuilder<T>(this,
            new QueryEngine(this, typeof(T)));
    }
}
