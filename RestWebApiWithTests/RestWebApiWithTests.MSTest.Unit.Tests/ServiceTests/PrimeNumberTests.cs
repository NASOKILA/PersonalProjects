using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestWebApiWithTests.Services;
using System;

namespace RestWebApiWithTests.MSTest.Unit.Tests.ServiceTests
{
    [TestClass]
    public class PrimeNumberTests
    {
        private readonly PrimeService _primeService;

        public PrimeNumberTests()
        {
            _primeService = new PrimeService();
        }

        [DataTestMethod]
        [DataRow(-1)]
        [DataRow(0)]
        [DataRow(1)]
        public void Prime_Check_Many_Inputs_Fails(int number)
        {
            //Arrange

            //Act
            bool result = _primeService.IsPrime(number);

            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Prime_Check_Input1_Returns_False()
        {
            //Arrange
            int number = 1;

            //Act
            bool result =_primeService.IsPrime(number);

            //Assert
            Assert.IsFalse(result);
            Assert.ThrowsException<ArgumentException>(() => throw new ArgumentException("Just like that !"));
            Assert.IsNotNull(result);
            Assert.IsNull(null);
            Assert.IsNotInstanceOfType(result, typeof(ArgumentException));
            Assert.IsInstanceOfType(result, typeof(Boolean));
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Prime_Check_Input5_Fails()
        {
            //Arrange
            int number = 5;

            //Act
            bool result = _primeService.IsPrime(number);

            //Assert
            Assert.AreNotSame(number, 2);
            Assert.AreEqual(number, 5);
            //Assert.Fail();
        }
    }
}
