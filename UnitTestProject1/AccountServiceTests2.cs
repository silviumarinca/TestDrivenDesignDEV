using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject1
{
    [TestClass]
   public class AccountServiceTests2
    {
        private AccountServiceBuilder _accountServiceBuilder;

        [TestInitialize]
        public void TestInitialize() 
        {
            _accountServiceBuilder = new AccountServiceBuilder();
        
        }

        [TestMethod]
        public void AddingTransactionToAccountDelegatesToAccountInstance()
        {
            var sut = _accountServiceBuilder
                  .WithAccountCalled("Trading Account")
                  .AddTransactionOfValue(200m)
                  .Build();
            sut.AddTransactionToAccount("Trading Account", 200m);

            _accountServiceBuilder.MockAccount.Verify();



        
        }
    }
}
