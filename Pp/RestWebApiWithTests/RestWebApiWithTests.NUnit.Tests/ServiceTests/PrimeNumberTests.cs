using NUnit.Framework;
using RestWebApiWithTests.Services;

namespace RestWebApiWithTests.NUnit.Tests.ServiceTests
{
    [TestFixture]
    public class PrimeNumberTests
    {
        private PrimeService _primeService;

        [SetUp]
        public void SetUp()
        {
            _primeService = new PrimeService();
        }

        [Test]
        public void Prime_Check_Input_5_Returns_True()
        {
            //Arrange
            int number = 5;

            //Act
            bool result = _primeService.IsPrime(number);

            //Assert
            Assert.True(result);
        }


        [Test]
        public void Prime_Check_Multiple_Inputs_Returns_False()
        {
            //Arrange
            int number = 1;
        
            //Act
            bool result = _primeService.IsPrime(number);

            //Assert
            Assert.Positive(number);
            Assert.Less(number, 2);
            Assert.LessOrEqual(number, 1);
            Assert.IsNotNull(number);
            Assert.NotZero(number);
            Assert.True(number < 2);
            Assert.False(number > 10);
            Assert.Pass("Test passed !");
        }

        [TestCase(-1)]
        [TestCase(0)]
        [TestCase(1)]
        [Test]
        public void Prime_Check_Many_Inputs_Returns_False(int number)
        {
            //Arrange
            
            //Act
            bool result = _primeService.IsPrime(number);

            //Assert
            Assert.False(result);
        }
    }
}