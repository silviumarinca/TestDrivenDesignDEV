using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using TestDrivenDesign;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Add()
        {
            //Arange
            var account = new Account();

            //Act
            account.AddTransaction(100m);
            account.AddTransaction(75m);
            //Assert
            Assert.AreEqual(175m, account.Balance);
        }
        [TestMethod]
        public void AddingTransactionToAccountDelegatesToAccountInstance()
        {
            var account = new Account();
            var fakeRepository = new FakeAccountRepository(account);
            var sut = new AccountService(fakeRepository);
            sut.AddTransactionToAccount("Trading Account", 200m);
            Assert.AreEqual(200m, account.Balance);
        }

        [TestMethod]
        public void AddingTransactionToAccountDelegatesToAccountInstanceMoq()
        {
            var account = new Account();
            var moqRepository = new Mock<IAccountRepository>();
            moqRepository.Setup(r => r.GetByName("Trading Account")).Returns(account);
            var sut = new AccountService(moqRepository.Object);
            sut.AddTransactionToAccount("Trading Account", 200m);
            Assert.AreEqual(200m, account.Balance);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CannotCreateAccountServiceWithNullAccountRepository() {
            ///Arrange
            ///
            //Act
            new AccountService(null);
          
        }
        [TestMethod]
        public void DoNotThrowWhenAccountIsNotFound() 
        {
            //Arange
            var mockRepository = new Mock<IAccountRepository>();
            var sut = new AccountService(mockRepository.Object);

            //Act
            sut.AddTransactionToAccount("Trading Account", 100m);
        
        
        }

        [TestMethod]
        [ExpectedException(typeof(ServiceException))]
        public void AccountExceptionAreWrappedInThrowServiceException() {

            var account = new Mock<Account>();
            account.Setup(a => a.AddTransaction(1m)).Throws<DomainException>();
            var mockRepository = new Mock<IAccountRepository>();
            mockRepository.Setup(r => r.GetByName("Trading Account")).Returns(account.Object);
            var sut = new AccountService(mockRepository.Object);

            //Act
            sut.AddTransactionToAccount("Trading Account", 1m);


        
        
        
        }


        [TestMethod]
        public void AccountExceptionsAreWrappedInThrowServiceException() 
        {
            var account = new Mock<Account>();
            account.Setup(r => r.AddTransaction(1m)).Throws<DomainException>();
            var mockRepository = new Mock<IAccountRepository>();
            mockRepository.Setup(r => r.GetByName("Trading account")).Returns(account.Object);

            var sut = new AccountService(mockRepository.Object);
            try
            {
                sut.AddTransactionToAccount("tRADING aCCOUNT", 1M);



            }
            catch (ServiceException exception)
            {
                Assert.IsInstanceOfType(exception.InnerException, typeof(DomainException));
            
            }
        
        }
    }
}
