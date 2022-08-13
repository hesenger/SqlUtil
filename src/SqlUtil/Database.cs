[assembly: CLSCompliant(true)]
namespace SqlUtil;

public class Database
{
    public string ConnectionString { get; set; }

    public Database(string connectionString)
    {
        ConnectionString = connectionString;
    }
}
