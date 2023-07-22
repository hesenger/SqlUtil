using System;

namespace SqlUtil;

public interface IUnityOfWork : IDisposable
{
    void Commit();
}
