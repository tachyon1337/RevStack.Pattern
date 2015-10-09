using System;
using System.Threading.Tasks;

namespace RevStack.Pattern
{
    public interface IUnitOfWork<TEntity,TKey> :IDisposable where TEntity : class, IEntity<TKey>
    {
        void Commit();
        Task CommitAsync();
    }
}
