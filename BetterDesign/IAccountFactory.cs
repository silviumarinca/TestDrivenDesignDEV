using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetterDesign
{
   public interface IAccountFactory
    {

        AccountBase createAccount(AccountType type);
    }
}
