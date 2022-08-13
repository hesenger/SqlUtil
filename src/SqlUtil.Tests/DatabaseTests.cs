using NUnit.Framework;

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
}