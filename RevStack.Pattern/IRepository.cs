using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace RevStack.Pattern
{
    public interface IRepository<TEntity, TKey> where TEntity : class, IEntity<TKey>
    {
        IEnumerable<TEntity> Get();
        IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        TEntity Add(TEntity entity);
        TEntity Update(TEntity entity);
        void Delete(TEntity entity);
    }
}
