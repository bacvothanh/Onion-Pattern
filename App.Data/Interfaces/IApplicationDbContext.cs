using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Data.Models;

namespace App.Data.Interfaces
{
    public interface IApplicationDbContext : IDisposable
    {
        int SaveChanges();
        Task<int> SaveChangesAsync();

        int ExecuteSqlCommand(string sql, bool doNotEnsureTransaction = false, int? timeout = null,
            params object[] parameters);

        DbSet Set(Type entityType);
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        DbEntityEntry Entry(object entity);
        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
        DbChangeTracker ChangeTracker { get; }
        
        DbSet<Account> Accounts { get; set; }
        DbSet<Role> Roles { get; set; }
    }
}
