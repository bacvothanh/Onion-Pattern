using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Data;
using App.Data.Interfaces;

namespace App.Repository
{
    public class DbContextScope
    {
        private readonly IApplicationDbContext _applicationDbContext;
        public DbContextScope()
        {
            _applicationDbContext = new ApplicationDbContext();
        }
    }
}
