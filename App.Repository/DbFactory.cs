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

        public DbFactory(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IApplicationDbContext Create()
        {
            return new ApplicationDbContext(_connectionString);
        }
    }
}
