using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetterDesign
{
    public class Account
    {
        private IAccountFactory accountFactory;
        private IAccountRepository accountRepository;
        public Account(IAccountFactory accountFactory, IAccountRepository accountRepository)
        {
            this.accountFactory = accountFactory;
            this.accountRepository = accountRepository;

        }
        private decimal balance { get; set; }
        public decimal amount { get; set; }
        public decimal Balance
        {
            get { return this.balance; }

            private set { this.balance = value; }
        }
      
     

        public Account()
        {

        }

        public int RewardPoints
        {
            get;
            private set;
        }

        public void CreateAccount(AccountType type)
        {
            var newAccount = accountFactory.createAccount(type);
            accountRepository.NewAccount(newAccount);

        }
    }

    public enum AccountType
    {
        Silver,
        Gold,
        Platinum

    }
}
