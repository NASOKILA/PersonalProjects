using RestWebApiWithTests.Services;
using Xunit;

namespace RestWebApiWithTests.Test.ServicesTest
{
    public class PromeNumberTests
    {
        private readonly PrimeService _primeService;

        public PromeNumberTests()
        {

            //SetUp for all tests
            _primeService = new PrimeService();
        }

        //If tests are very similar we can use [Theory] and [InlineData()] to pass similar data in the same test.
        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        [InlineData(1)]
        public void IsPrime_Inputs_Multiple_Values_Returns_False(int number)
        {
            //Arrange

            //Act
            bool result = _primeService.IsPrime(number);

            //Assert
            Assert.False(result);
        }

        [Theory]
        [InlineData(97)]
        [InlineData(89)]
        [InlineData(61)]
        public void IsPrime_Inputs_Multiple_Values_Returns_True(int number)
        {
            //Arrange

            //Act
            bool result = _primeService.IsPrime(number);

            //Assert
            Assert.True(result);
        }

        [Fact]
        public void IsPrime_Inputs_2_Returns_True()
        {
            //Arrange
            int number = 2;

            //Act
            bool result = _primeService.IsPrime(number);

            //Assert
            Assert.True(result);
        }

      
        [Fact]
        public void IsPrime_Inputs_5_Returns_True()
        {
            //Arrange
            int number = 5;

            //Act
            bool result = _primeService.IsPrime(number);

            //Assert
            Assert.True(result);
        }
        
        [Fact]
        public void IsPrime_Inputs_Zero_Returns_True()
        {
            //Arrange
            int number = 0;

            //Act
            bool result = _primeService.IsPrime(number);

            //Assert
            Assert.False(result);
        }

        [Fact]
        public void IsPrime_Inputs_OneThousand_Returns_True()
        {
            //Arrange
            int number = 1000;

            //Act
            bool result = _primeService.IsPrime(number);

            //Assert
            Assert.False(result);
        }
    }
}
