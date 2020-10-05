using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetterDesign
{
  public  class AccountService:IAccountService
    {
        
        public AccountService(IAccountRepository repo)
        {
            if (repo == null) throw new ArgumentNullException("AccountError");
            this.repository = repo;
                
        }
        public void AddTransactionToAccount(string uniqueAccountName, decimal transactionAmount)
        {
            var account = repository.GetByName(uniqueAccountName);
            if (account != null)
            {
                try
                {
                    account.AddTransaction(transactionAmount);

                }
                catch (DomainException ex)
                {
                    throw new ServiceException("Adding transaction to account failed",ex);
                }
            }
        }
        private readonly IAccountRepository repository;
    }
}
