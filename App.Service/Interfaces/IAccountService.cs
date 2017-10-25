using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Data.Models;
using App.Infrastructure;
using App.ViewModel;

namespace App.Service.Interfaces
{
    public interface IAccountService : IGenericService<Account>
    {
        ApplicationResult Insert(RegisterBindingModel model);
    }
}
