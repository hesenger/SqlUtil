using System.Collections.ObjectModel;

namespace SqlUtil.Infra;

public interface ICommitListener
{
    void OnCommit(ReadOnlyCollection<object> trackedObjects);
}
