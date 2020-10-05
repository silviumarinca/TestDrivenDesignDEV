using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDrivenDesign
{
    public class FakeAccountRepository : IAccountRepository
    {
        private Account account;
        public FakeAccountRepository(Account account)
        {
            this.account = account;

        }
        public Account GetByName(string accountName)
        {

            return account;

        }
    }
}
