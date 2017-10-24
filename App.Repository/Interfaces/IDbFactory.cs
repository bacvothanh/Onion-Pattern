using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Data.Interfaces;

namespace App.Repository.Interfaces
{
    public interface IDbFactory
    {
        IApplicationDbContext Create();
    }
}
