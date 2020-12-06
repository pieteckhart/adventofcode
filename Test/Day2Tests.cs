using System;
using System.Security.Cryptography;
using Advent;
using Xunit;


namespace Test
{
    public class Day2Tests
    {
        [Theory]
        [InlineData("1-3 a: abcde", true)]
        [InlineData("1-3 b: cdefg", false)]
        [InlineData("2-9 c: ccccccccc", true)]
        public void ValidPassword(string inputRow, bool expected)
        {
            var isValid = Day2.IsValidPassword1(inputRow);

            Assert.Equal(expected, isValid);
        }

        [Theory]
        [InlineData("1-3 a: abcde", true)]
        [InlineData("1-3 b: cdefg", false)]
        [InlineData("2-9 c: ccccccccc", false)]
        public void ValidPassword2(string inputRow, bool expected)
        {
            var isValid = Day2.IsValidPassword2(inputRow);

            Assert.Equal(expected, isValid);
        }

        [Fact]
        public void validCountPolicy1()
        {
            var answer = Day2.CountValidPasswordsPolicy1();
            Assert.Equal(393,answer);
        }

        [Fact]
        public void validCountPolicy2()
        {
            var answer = Day2.CountValidPasswordsPolicy2();
            Assert.Equal(690, answer);
        }
    }
}
