namespace Bibliocine.Core.Data;

public interface IRepository<TAggregate> : IDisposable 
    where TAggregate : IAggregateRoot
{
    IUnityOfWork UnityOfWork { get; }
}