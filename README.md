# SqlUtil

[![Nuget Package](https://img.shields.io/nuget/v/SqlUtil.svg)](https://www.nuget.org/packages/FluentMigrator/)
[![NuGet Downloads](https://img.shields.io/nuget/dt/SqlUtil.svg)](https://www.nuget.org/packages/FluentMigrator/)

SqlUtil is a convention over configuration ORM intended to be used by
new projects without a hard data structure to follow. The idea is to provide
an easy and thin data access layer without use of annotations or extra
configurations keeping the POCOs as actual POCOs.

## History

I wrote this package in 2014 while working on
[Report4](https://www.nuget.org/packages/Report4/) and I got surprised with
the amount of downloads. I'm investing a bit of time in updating this to dotnet
core and doing a few improvements.

## Reporting bugs or requesting features

When reporting bugs it's good to have a written test. I will do when solving
those but if you have chance to write it the process will speed up.

## Examples

```csharp
var db = new Database(connectionString);
var users = db.From<User>()
    .LeftJoin(x => x.Group)
    .Select();

users.ForEach(user => Console.WriteLine(user));

public class User
{
    public int Id { get; set; }
    public string Username { get; set; }
    public Group Group { get; set; }
}

public class Group
{
    public int Id { get; set; }
    public string Name { get; set; }
}
```

## Version 2

Version 2 is fully converted to dotnet 6, although I try to still maintaining
the Version 1 with minor updates, this is a library focused on new projects
and if you are creating new projects in .NET Framework 4 🤷‍♂️.

## Contributing

Some rules are needed, though feel free to open Pull Requests and we will
discuss about design or other concerns. Code reviewing is one of the most
exciting advantages of modern software development.

Since the project is focused in assume patterns (convention over configuration)
bear in mind some points.:

- Tables and column names will match exatcly (case sensitive) classes and
  properties, unless there is a NamingConvention involved;

- No `internal` or `sealed` classes at all, this is a open source project and
  we want anyone that wants to change some behavior do it;

- No public static methods or properties for the same reason above, they are not
  overwritable, but there's no problem with private static methods to improve
  readability;

- Tests everywhere! This is a library so write and update tests when doing
  changes;

### Environment to contribute

In theory you are able to use the full version of Visual Studio, though I'm
currently working using vscode from a mac m1 (dotnet 6) and only running tests
on Windows. Feel free to open a PR with required changes if needed.

## References

- [Mighty](https://github.com/MightyOrm/Mighty)
- [OrmLite](https://docs.servicestack.net/ormlite)
- [FluentMigrator](https://github.com/fluentmigrator/fluentmigrator)
