using SqlUtil.Schema;

[assembly: CLSCompliant(true)]
namespace SqlUtil;

public class Database
{
    public Database(
        string connectionString,
        INamingConvention? namingConvention = null)
    {
        ConnectionString = connectionString;
        NamingConvention = namingConvention ?? new DefaultNamingConvention();
    }

    public virtual string ConnectionString { get; set; }

    public virtual INamingConvention NamingConvention { get; set; }

    public virtual QueryBuilder<T> From<T>() where T : class
    {
        return new QueryBuilder<T>(this);
    }
}
