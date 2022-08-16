using NUnit.Framework;
using SqlUtil.Tests.Models;

namespace SqlUtil.Tests;

[TestFixture]
public class DatabaseTests
{
    [Test]
    public void SettingsWereLoaded()
    {
        var db = new Database(TestsGlobal.Settings?.ConnectionString!);
        Assert.That(db.ConnectionString, Is.Not.Null);
    }

    [Test]
    public void All()
    {
        var db = new Database(TestsGlobal.Settings!.ConnectionString!);
        var all = db.From<User>().All();

        Assert.That(all, Has.Count.EqualTo(0));
    }

    [Test]
    public void JoinAll()
    {
        var db = new Database(TestsGlobal.Settings!.ConnectionString!);
        var all = db
            .From<User>()
            .LeftJoin(x => x.Group)
            .LeftJoin((user, group) => group.Name)
            .All();

        Assert.That(all, Has.Count.EqualTo(0));
    }
}
