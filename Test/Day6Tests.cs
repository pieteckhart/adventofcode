using System;
using System.IO;
using System.Net;
using System.Net.WebSockets;
using System.Security.Cryptography;
using Advent;
using Xunit;


namespace Test
{
    public class Day6Tests
    {
        [Fact]
        public void FirstGroup()
        {
            var input = @"abcx
abcy
abcz";
            var scanner = new CustomsDeclarationsScanner(input);
            var uniqueYesAnswers = scanner.ScanSumDistinct();
            Assert.Equal(6, uniqueYesAnswers);
        }

        [Fact]
        public void SecondGroup()
        {
            var input = @"abc";
            var scanner = new CustomsDeclarationsScanner(input);
            var uniqueYesAnswers = scanner.ScanSumDistinct();
            Assert.Equal(3, uniqueYesAnswers);
        }

        [Fact]
        public void ThirdGroup()
        {
            var input = @"a
b
c";
            var scanner = new CustomsDeclarationsScanner(input);
            var uniqueYesAnswers = scanner.ScanSumDistinct();
            Assert.Equal(3, uniqueYesAnswers);
        }

        [Fact]
        public void FourthGroup()
        {
            var input = @"ab
ac";
            var scanner = new CustomsDeclarationsScanner(input);
            var uniqueYesAnswers = scanner.ScanSumDistinct();
            Assert.Equal(3, uniqueYesAnswers);
        }

        [Fact]
        public void FifthGroup()
        {
            var input = @"a
a
a
a";
            var scanner = new CustomsDeclarationsScanner(input);
            var uniqueYesAnswers = scanner.ScanSumDistinct();
            Assert.Equal(1, uniqueYesAnswers);
        }

        [Fact]
        public void SixthGroup()
        {
            var input = @"b";
            var scanner = new CustomsDeclarationsScanner(input);
            var uniqueYesAnswers = scanner.ScanSumDistinct();
            Assert.Equal(1, uniqueYesAnswers);
        }

        [Fact]
        public void ScanSumDistinct()
        {
            var input = File.ReadAllText(@"inputs\day06.txt");

            var scanner = new CustomsDeclarationsScanner(input);
            var sumOfAnswers = scanner.ScanSumDistinct();
            Assert.Equal(6590, sumOfAnswers);
        }

        [Fact]
        public void FirstGroupB()
        {
            var input = @"abcx
abcy
abcz";
            var scanner = new CustomsDeclarationsScanner(input);
            var unanymousYesAnswers = scanner.ScanSumUnanimous();
            Assert.Equal(3, unanymousYesAnswers);
        }

        [Fact]
        public void SecondGroupB()
        {
            var input = @"abc";
            var scanner = new CustomsDeclarationsScanner(input);
            var unanymousYesAnswers = scanner.ScanSumUnanimous();
            Assert.Equal(3, unanymousYesAnswers);
        }

        [Fact]
        public void ThirdGroupB()
        {
            var input = @"a
b
c";
            var scanner = new CustomsDeclarationsScanner(input);
            var unanymousYesAnswers = scanner.ScanSumUnanimous();
            Assert.Equal(0, unanymousYesAnswers);
        }

        [Fact]
        public void FourthGroupB()
        {
            var input = @"ab
ac";
            var scanner = new CustomsDeclarationsScanner(input);
            var unanymousYesAnswers = scanner.ScanSumUnanimous();
            Assert.Equal(1, unanymousYesAnswers);
        }

        [Fact]
        public void FifthGroupB()
        {
            var input = @"a
a
a
a";
            var scanner = new CustomsDeclarationsScanner(input);
            var unanymousYesAnswers = scanner.ScanSumUnanimous();
            Assert.Equal(1, unanymousYesAnswers);
        }

        [Fact]
        public void SixthGroupB()
        {
            var input = @"b";
            var scanner = new CustomsDeclarationsScanner(input);
            var unanymousYesAnswers = scanner.ScanSumUnanimous();
            Assert.Equal(1, unanymousYesAnswers);

        }

        [Fact]
        public void ScanSumUnanimous()
        {
            var input = File.ReadAllText(@"inputs\day06.txt");

            var scanner = new CustomsDeclarationsScanner(input);
            var sumOfAnswers = scanner.ScanSumUnanimous();
            Assert.Equal(3288, sumOfAnswers);
        }
    }
}
