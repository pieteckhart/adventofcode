using System;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using Advent;
using Xunit;


namespace Test
{
    public class Day4Tests
    {
        [Fact]
        public void Valid()
        {
            var input = @"ecl:gry pid:860033327 eyr:2020 hcl:#fffffd
byr:1937 iyr:2017 cid:147 hgt:183cm";

            var validCount = new APS(input).GetValidCount();

            Assert.Equal(1, validCount);
        }

        [Fact]
        public void NoHeight()
        {
            var input = @"iyr:2013 ecl:amb cid:350 eyr:2023 pid:028048884
hcl:#cfa07d byr:1929";

            var validCount = new APS(input).GetValidCount();

            Assert.Equal(0, validCount);
        }

        [Fact]
        public void NoCID()
        {
            var input = @"hcl:#ae17e1 iyr:2013
        eyr:2024
        ecl:brn pid:760753108 byr:1931
        hgt:179cm";

            var validCount = new APS(input).GetValidCount();

            Assert.Equal(1, validCount);
        }

        [Fact]
        public void AlsoInvalid()
        {
            var input = @"hcl:#cfa07d eyr:2025 pid:166559648
        iyr:2011 ecl:brn hgt:59in";

            var validCount = new APS(input).GetValidCount();

            Assert.Equal(0, validCount);
        }

        [Fact]
        public void CountAllValid()
        {
            var input = File.ReadAllText(@"inputs\day04.txt");

            var validCount = new APS(input).GetValidCount();

            Assert.Equal(109, validCount);
        }

        [Theory]
        [InlineData("2002", true)]
        [InlineData("2003", false)]
        public void byr(string value, bool expected)
        {
            Assert.Equal(expected, APS.isBYRvalid(value));
        }

        [Theory]
        [InlineData("60in", true)]
        [InlineData("190cm", true)]
        [InlineData("190in", false)]
        [InlineData("190", false)]
        public void hgt(string value, bool expected)
        {
            Assert.Equal(expected, APS.isHGTvalid(value));
        }

        [Theory]
        [InlineData("#123abc", true)]
        [InlineData("#123abz", false)]
        [InlineData("123abc", false)]
        public void hcl(string value, bool expected)
        {
            Assert.Equal(expected, APS.IsHCLvalid(value));
        }

        [Theory]
        [InlineData("brn", true)]
        [InlineData("wat", false)]
        public void ecl(string value, bool expected)
        {
            Assert.Equal(expected, APS.IsECLvalid(value));
        }

        [Theory]
        [InlineData("000000001", true)]
        [InlineData("0123456789", false)]
        [InlineData("1234567896", false)]
        public void pid(string value, bool expected)
        {
            Assert.Equal(expected, APS.IsPIDvalid(value));
        }
    }
}
