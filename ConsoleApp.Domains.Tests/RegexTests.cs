using ConsoleApp.Domains.Entities;
using System.Text.RegularExpressions;

namespace ConsoleApp.Domains.Tests
{
    public class RegexTests
    {
        [Fact]
        public void RegexValidValueTest()
        {
            //AAA
            //Arrange
            Regex regex = new Regex(RegexPattern.AccountNumberPattern);
            string account = "2025-00000001";
            //Act

            bool result = regex.Match(account).Success;

            //Assert
            Assert.True(result);
        }

        [Fact]
        public void RegexInvalidValueTest()
        {
            //AAA
            //Arrange
            Regex regex = new Regex(RegexPattern.AccountNumberPattern);
            string account = "2025-0000001";
            //Act

            bool result = regex.Match(account).Success;

            //Assert
            Assert.False(result);
        }

        [Theory]
        [InlineData("2025-00000001", true)]
        [InlineData("2025-0000001", false)]
        [InlineData("0000-00000000", true)]
        [InlineData("202-00000001", false)]
        public void RegexValuesTest(string account, bool expectedResult)
        {
            //AAA
            //Arrange
            Regex regex = new Regex(RegexPattern.AccountNumberPattern);
            
            //Act
            bool result = regex.Match(account).Success;

            //Assert
            Assert.Equal(expectedResult, result);
        }
    }
}