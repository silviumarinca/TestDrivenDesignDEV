using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetterDesign
{
   public class AccountFactory : IAccountFactory
    {
        public AccountBase createAccount(AccountType type)
        {
            AccountBase account = null;
            switch (type)
            {
                case AccountType.Silver:
                    account = new SilverAccount();
                    break;
                case AccountType.Gold:
                    account = new GoldAccount();
                    break;
                case AccountType.Platinum:
                    account = new PlatinumAccount();
                    break;
            
            
            }
            return account;
        }

        public AccountBase CreateAccount(string accountType)
        {
            var objectHandle = Activator.CreateInstance(null, string.Format("{0}Account", accountType));
            return (AccountBase)objectHandle.Unwrap();  
        
        
        }
    }
}
