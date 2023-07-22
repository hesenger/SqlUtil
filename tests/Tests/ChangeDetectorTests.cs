using SqlUtil.Infra;

namespace Tests;

public class ChangeDetectorTests
{
    [Fact]
    public void It_detects_property_changes()
    {
        var user = new User();
        var detector = new ChangeDetector(user);
        user.Name = "John";

        Assert.True(detector.HasChanges());
    }

    [Fact]
    public void It_has_no_changes_when_object_is_pristine()
    {
        var user = new User();
        var detector = new ChangeDetector(user);

        Assert.False(detector.HasChanges());
    }

    [Fact]
    public void It_returns_changed_property()
    {
        var user = new User { Name = "John" };
        var detector = new ChangeDetector(user);

        user.Name = "Jane";

        var changes = detector.GetChanges();
        var change = changes.FirstOrDefault();

        Assert.Equal("Name", change.Key.Name);
    }
}