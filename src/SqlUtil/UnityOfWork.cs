using SqlUtil.Infra;

namespace SqlUtil;

public class UnityOfWork : IUnityOfWork
{
    private readonly List<object> _trackedObjects = new();
    private readonly ICommitListener? _commitListener;

    public UnityOfWork(ICommitListener? commitListener = null)
    {
        _commitListener = commitListener;
    }

    public void Track(object obj)
    {
        _trackedObjects.Add(obj);
    }

    public bool IsTracked(object obj)
    {
        return _trackedObjects.Contains(obj);
    }

    public void Commit()
    {
        _commitListener?.OnCommit(_trackedObjects.AsReadOnly());
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);

        _trackedObjects.Clear();
    }
}