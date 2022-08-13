using NUnit.Framework;

namespace SqlUtil.Tests;

[TestFixture]
public class DatabaseTests
{
    [Test]
    public void Test()
    {
        var db = new Database();
        Assert.IsNotNull(db);
    }
}