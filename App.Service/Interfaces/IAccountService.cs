using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Infrastructure;
using App.ViewModel;

namespace App.Service.Interfaces
{
    public interface IAccountService
    {
        ApplicationResult Insert(RegisterBindingModel model);
    }
}
