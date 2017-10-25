using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Data.Models;
using App.Infrastructure;
using App.Service.Interfaces;
using App.Repository;
using App.Repository.Interfaces;
using App.ViewModel;

namespace App.Service
{
    public class AccountService : GenericService<Account>,IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        public AccountService(IAccountRepository accountRepository) : base(accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public ApplicationResult Insert(RegisterBindingModel model)
        {
            var existAccount =
                _accountRepository.Get(x => x.Email == model.Email || x.UserName == model.UserName).FirstOrDefault();
            if (existAccount != null)
                return ApplicationResult.Fail(ApplicationErrorCode.ErrorIsExist, "Account Email Or Username");
            
            throw new NotImplementedException();
        }

    }
}
