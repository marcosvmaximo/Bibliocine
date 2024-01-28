namespace Bibliocine.Core.Data;

public interface IUnityOfWork
{
    Task<bool> Commit();
}