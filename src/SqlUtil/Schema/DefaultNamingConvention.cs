namespace SqlUtil.Schema;

public class DefaultNamingConvention : INamingConvention
{
    public virtual string Pluralize(string name)
    {
        return name + "s";
    }
}