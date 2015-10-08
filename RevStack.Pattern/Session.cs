using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using RevStack.Mvc;

namespace RevStack.Pattern
{
    public class Session<TEntity, TKey> : IService<TEntity, TKey> where TEntity : class, IEntity<TKey>
    {
        private readonly IRepository<TEntity, TKey> _repository;
        private readonly IUnitOfWork<TEntity, TKey> _unitOfWork;
        public Session(IRepository<TEntity, TKey> repository, IUnitOfWork<TEntity, TKey> unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public virtual IEnumerable<TEntity> Get()
        {
            return _repository.Get();
        }

        public virtual Task<IEnumerable<TEntity>> GetAsync()
        {
            return Task.FromResult(Get());
        }

        public virtual IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return _repository.Find(predicate);
        }

        public virtual Task<IQueryable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return Task.FromResult(Find(predicate));
        }

        public virtual TEntity Add(TEntity entity)
        {
            _repository.Add(entity);
            _unitOfWork.Commit();
            return entity;
        }

        public virtual Task<TEntity> AddAsync(TEntity entity)
        {
            return Task.FromResult(Add(entity));
        }

        public virtual TEntity Update(TEntity entity)
        {
            _repository.Update(entity);
            _unitOfWork.Commit();
            return entity;
        }

        public virtual Task<TEntity> UpdateAsync(TEntity entity)
        {
            return Task.FromResult(Update(entity));
        }

        public virtual void Delete(TEntity entity)
        {
            _repository.Delete(entity);
            _unitOfWork.Commit();
        }

        public virtual Task DeleteAsync(TEntity entity)
        {
            return Task.Run(() => Delete(entity));
        }

    }
}
