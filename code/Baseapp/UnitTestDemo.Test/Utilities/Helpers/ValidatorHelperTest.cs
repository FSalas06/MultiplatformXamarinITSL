using UnitTestDemo.Utilities.Helpers;
using Xunit;

namespace UnitTestDemo.Test.Utilities.Helpers
{
    public class ValidatorHelperTest
    {
        [Theory]
        [InlineData("Javs")]
        [InlineData("Ulises")]        
        public void IsValidUsername_CorrectUsername_ReturnTrue(string username) 
        {
            //Arrange
            var validatorHelper = new ValidatorHelper();            

            //Act
            var result = validatorHelper.IsValidUsername(username);

            //Assert
            Assert.True(result);
        }

        [Theory]
        [InlineData("     ")]
        [InlineData("")]
        [InlineData(null)]
        public void IsValidUsername_IncorrectUsername_ReturnFalse(string username)
        {
            //Arrange
            var validatorHelper = new ValidatorHelper();

            //Act
            var result = validatorHelper.IsValidUsername(username);

            //Assert
            Assert.False(result);
        }

        [Theory]
        [InlineData("Pass")]
        [InlineData("Abcd123")]
        public void IsValidPassword_CorrectPassword_ReturnTrue(string password)
        {
            //Arrange
            var validatorHelper = new ValidatorHelper();

            //Act
            var result = validatorHelper.IsValidPassword(password);

            //Assert
            Assert.True(result);
        }

        [Theory]
        [InlineData("     ")]
        [InlineData("")]
        [InlineData(null)]
        [InlineData("Ab")]
        public void IsValidPassword_IncorrectPassword_ReturnFalse(string password)
        {
            //Arrange
            var validatorHelper = new ValidatorHelper();

            //Act
            var result = validatorHelper.IsValidPassword(password);

            //Assert
            Assert.False(result);
        }
    }
}
