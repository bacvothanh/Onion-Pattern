using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using App.Infrastructure;
using App.Repository.Interfaces;
using App.Service.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;

namespace App.Service
{
    public class GenericService<TEntity>
    {
        private readonly IGenericRepository<TEntity> _repository;
        protected GenericService(IGenericRepository<TEntity> repository)
        {
            _repository = repository;
        }

        public virtual T GetByIdOrDefault<T>(object id)
        {
            return Mapper.Map<T>(_repository.GetById(id));
        }

        public virtual ApplicationResult<T> GetById<T>(object id)
        {
            var entity = _repository.GetById(id);
            if (entity == null)
                return ApplicationResult.Fail<T>($"Cannot find {typeof(T)} with Id:{id} in the system");
            return ApplicationResult.Ok(Mapper.Map<T>(entity));
        }

        public virtual IEnumerable<T> Get<T>(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            params Expression<Func<TEntity, object>>[] includeProperties)
        {
            return _repository.Get(filter, orderBy, includeProperties).AsQueryable().ProjectTo<T>();
        }

        public virtual void Delete(object id)
        {
            _repository.Delete(id);
        }

        public virtual void Delete(TEntity entityToDelete)
        {
            _repository.Delete(entityToDelete);
        }
    }
}
