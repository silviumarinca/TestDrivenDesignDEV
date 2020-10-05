using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDrivenDesign;

namespace UnitTestProject1
{
    [TestClass]
    public  class AccountServiceTests
    {
        private Mock<Account> mockAccount;
        private Mock<IAccountRepository> mockRepository;
        private AccountService sut;

        [TestInitialize]
        public void Setup() 
        {
            mockAccount = new Mock<Account>();
            mockRepository = new Mock<IAccountRepository>();
            sut = new AccountService(mockRepository.Object);
        
        }

        [TestMethod]
        public void AccountExceptionsAreWrappedInThrowServiceException() 
        {
            mockAccount.Setup(a => a.AddTransaction(100m)).Throws<DomainException>();
            mockRepository.Setup(r => r.GetByName("Trading account")).Returns(mockAccount.Object);
            try
            {

                sut.AddTransactionToAccount("Trading Account", 100m);


            }
            catch (ServiceException serviceException) 
            {
                Assert.IsInstanceOfType(serviceException.InnerException, typeof(DomainException));
            
            }
        
        }

        [TestMethod]
        public void AddingTransactionToAccountDelegatesToAccountInstance() {
            //Arrange
            var account = new Account();
            var mockRepository = new Mock<IAccountRepository>();
            mockRepository.Setup(r => r.GetByName("Trading Account")).Returns(account);
            var sut = new AccountService(mockRepository.Object);

            //Act
            sut.AddTransactionToAccount("Trading Account",100m);
            //Assert
            Assert.AreEqual(200m, account.Balance);

        
        
        }


    }
}
