using System.Reflection;

namespace SqlUtil.Infra;

public class ChangeDetector
{
    private readonly object _obj;
    private readonly Dictionary<PropertyInfo, object?> _initialValues = new();

    public ChangeDetector(object obj)
    {
        _obj = obj;
        _obj.GetType()
            .GetProperties()
            .Where(p => p.CanRead && p.CanWrite)
            .ToList()
            .ForEach(p => _initialValues.Add(p, p.GetValue(_obj)));
    }

    public bool HasChanges()
    {
        return _initialValues.Any(p => !Equals(p.Value, p.Key.GetValue(_obj)));
    }

    public Dictionary<PropertyInfo, object?> GetChanges()
    {
        return _initialValues
            .Where(p => !Equals(p.Value, p.Key.GetValue(_obj)))
            .ToDictionary(p => p.Key, p => p.Key.GetValue(_obj));
    }
}