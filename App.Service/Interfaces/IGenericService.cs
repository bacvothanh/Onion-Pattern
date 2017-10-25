using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using App.Infrastructure;

namespace App.Service.Interfaces
{
    public interface IGenericService<TEntity>
    {
        T GetByIdOrDefault<T>(object id);
        ApplicationResult<T> GetById<T>(object id);

        IEnumerable<T> Get<T>(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            params Expression<Func<TEntity, object>>[] includeProperties);

        void Delete(object id);
        void Delete(TEntity entityToDelete);
    }
}
