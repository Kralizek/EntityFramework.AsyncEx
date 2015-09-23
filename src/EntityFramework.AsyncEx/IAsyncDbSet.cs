using System.Threading.Tasks;

// ReSharper disable once CheckNamespace
namespace System.Data.Entity
{
    public interface IAsyncDbSet<T> : IDbSet<T> where T : class
    {
        Task<T> FindAsync(params object[] keyValues);
    }
}