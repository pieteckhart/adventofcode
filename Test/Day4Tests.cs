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
            var input = File.ReadAllText(@"inputs\day04.txt"); ;

            var validCount = new APS(input).GetValidCount();

            Assert.Equal(182, validCount);
        }
    }
}
