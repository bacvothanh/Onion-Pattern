using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using App.Data.Interfaces;
using App.Data.Shared;
using App.Repository.Interfaces;

namespace App.Repository
{
    public class GenericRepository<TEntity> where TEntity : class
    {
        private readonly IDbFactory _dbFactory;

        public GenericRepository(IDbFactory dbFactory)
        {
            _dbFactory = dbFactory;
        }
        
        public virtual IEnumerable<TEntity> Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            params Expression<Func<TEntity, object>>[] includeProperties)
        {
            using (var db = _dbFactory.Create())
            {
                IQueryable<TEntity> query = db.Set<TEntity>();

                if (filter != null)
                {
                    query = query.Where(filter);
                }

                foreach (var includeProperty in includeProperties)
                    query = query.Include(includeProperty);

                if (orderBy != null)
                {
                    return orderBy(query).ToList();
                }

                return query.ToList();
            }
        }

        public virtual TEntity GetById(object id)
        {
            using (var db = _dbFactory.Create())
            {
                return db.Set<TEntity>().Find(id);
            }
        }

        public virtual void Insert(TEntity entity)
        {
            using (var db = _dbFactory.Create())
            {
                db.Set<TEntity>().Add(entity);
                db.SaveChanges();
            }
        }

        public virtual void Delete(object id)
        {
            using (var db = _dbFactory.Create())
            {
                var dbSet = db.Set<TEntity>();
                var entityToDelete = dbSet.Find(id);
                var entity = entityToDelete as IDeleteEntity;
                if (entity != null)
                {
                    var deleteEntity = entity;
                    deleteEntity.IsDeleted = true;
                    deleteEntity.TimeDeleteOnUtc = DateTime.UtcNow;
                    var currentUser = CustomPrincipal.GetCurrentUser();
                    if (currentUser != null)
                    {
                        deleteEntity.DeleteBy = currentUser.Id;
                    }

                    dbSet.Attach(entityToDelete);
                    db.Entry(entityToDelete).State = EntityState.Modified;
                    db.SaveChanges();
                    return;
                }

                dbSet.Remove(entityToDelete);
                db.SaveChanges();
            }
        }

        public virtual void Delete(TEntity entityToDelete)
        {
            using (var db = _dbFactory.Create())
            {
                var dbSet = db.Set<TEntity>();
                if (db.Entry(entityToDelete).State == EntityState.Detached)
                {
                    dbSet.Attach(entityToDelete);
                }

                var entity = entityToDelete as IDeleteEntity;
                if (entity != null)
                {
                    var deleteEntity = entity;
                    deleteEntity.IsDeleted = true;
                    deleteEntity.TimeDeleteOnUtc = DateTime.UtcNow;
                    var currentUser = CustomPrincipal.GetCurrentUser();
                    if (currentUser != null)
                    {
                        deleteEntity.DeleteBy = currentUser.Id;
                    }
                    
                    db.SaveChanges();
                    return;
                }

                dbSet.Remove(entityToDelete);
                db.SaveChanges();
            }
        }

        public virtual void Update(TEntity entityToUpdate)
        {
            using (var db = _dbFactory.Create())
            {
                var dbSet = db.Set<TEntity>();
                dbSet.Attach(entityToUpdate);
                db.Entry(entityToUpdate).State = EntityState.Modified;
                db.SaveChanges();
            }
        }
    }
}
