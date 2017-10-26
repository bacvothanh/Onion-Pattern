using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Data;
using App.Data.Interfaces;
using App.Repository.Interfaces;

namespace App.Repository
{
    public class DbFactory : IDbFactory
    {
        private readonly string _connectionString;
        private static readonly object LockObject = new object();

        public DbFactory(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IApplicationDbContext Create()
        {
            lock (LockObject)
            {
                return new ApplicationDbContext(_connectionString);
            }
        }
    }
}
