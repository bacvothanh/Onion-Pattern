using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Data.Interfaces;
using App.Data.Models;
using App.Repository.Interfaces;

namespace App.Repository
{
    public class AccountRepository : GenericRepository<Account> , IAccountRepository
    {
        public AccountRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
