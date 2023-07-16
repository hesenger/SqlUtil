using System.Collections.ObjectModel;
using Moq;
using SqlUtil;
using SqlUtil.Infra;

namespace Tests;

public class UnityOfWorkTests
{
    [Fact]
    public void It_tracks_instance_of_objects()
    {
        var uow = new UnityOfWork();
        var obj = new object();

        uow.Track(obj);

        Assert.True(uow.IsTracked(obj));
    }

    [Fact]
    public void It_calls_commit_listener_with_tracked_objects()
    {
        var mock = new Mock<ICommitListener>();
        var uow = new UnityOfWork(mock.Object);
        var obj = new object();
        uow.Track(obj);

        uow.Commit();

        mock.Verify(x =>
            x.OnCommit(
                It.Is<ReadOnlyCollection<object>>(y => y.Contains(obj))));
    }
}