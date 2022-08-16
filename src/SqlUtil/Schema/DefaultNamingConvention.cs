namespace SqlUtil.Schema;

public class DefaultNamingConvention : INamingConvention
{
    /// <summary>
    /// Pluralizes a table name. To disable pluralization override this method 
    /// and return the same name. You can specify a custom name convention in 
    /// the constructor of the <see cref="Database"/> class.
    /// </summary>
    public virtual string Pluralize(string name)
    {
        return name + "s";
    }
}