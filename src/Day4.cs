using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;

namespace Advent
{
    public class APS
    {
        string regex = @"(\w{3}):([\w+#]+)";
        private string[] passports;

        public APS(string input)
        {
            var passports = input.Split(Environment.NewLine+Environment.NewLine);
            this.passports = passports;
        }

        public int GetValidCount()
        {
            var validCount = 0;
            foreach (var input in passports)
            {
                var result = Regex.Matches(input, regex).Select(m => new {key = m.Groups[1].Value, value = m.Groups[2].Value});
                var passport = new
                {
                    byr = result.FirstOrDefault(g => g.key == "byr"),
                    iyr = result.FirstOrDefault(g => g.key == "iyr"),
                    eyr = result.FirstOrDefault(g => g.key == "eyr"),
                    hgt = result.FirstOrDefault(g => g.key == "hgt"),
                    hcl = result.FirstOrDefault(g => g.key == "hcl"),
                    ecl = result.FirstOrDefault(g => g.key == "ecl"),
                    pid = result.FirstOrDefault(g => g.key == "pid"),
                    cid = result.FirstOrDefault(g => g.key == "cid"),
                };

                validCount = (passport.byr != null && isBYRvalid(passport.byr.value)
                       && passport.iyr != null && isIYRvalid(passport.iyr.value)
                       && passport.eyr != null && isEYRvalid(passport.eyr.value)
                       && passport.hgt != null && isHGTvalid(passport.hgt.value)
                       && passport.hcl != null && IsHCLvalid(passport.hcl.value)
                       && passport.ecl != null && IsECLvalid(passport.ecl.value)
                       && passport.pid != null) && IsPIDvalid(passport.pid.value)
                    ? validCount+1
                    : validCount;
            }

            return validCount;
        }

        public static bool IsPIDvalid(string value) => Regex.IsMatch(value,@"\A\d{9}\z");

        public static bool IsECLvalid(string value) => value switch
        {
            "amb" => true,
            "blu" => true,
            "brn" => true,
            "gry" => true,
            "grn" => true,
            "hzl" => true,
            "oth" => true,
            _ => false
        };

        public static bool IsHCLvalid(string value) => Regex.IsMatch(value, @"#[\da-f]{6}");

        public static bool isHGTvalid(string value)
        {
            var hgt = Regex.Match(value, @"(\d+)([c-n]{2})");
            if (!hgt.Success)
                return false;

            int number = int.Parse(hgt.Groups[1].Value);
            var unit = hgt.Groups[2].Value;

            return unit switch
            {
                "cm" => number >= 150 && number <= 193,
                "in" => number >= 59 && number <= 76,
                _ => false
            };
        }

        public static bool isEYRvalid(string value) =>
            int.TryParse(value, out int year)
            && year >= 2020
            && year <= 2030;

        public static bool isIYRvalid(string value) =>
            int.TryParse(value, out int year)
            && year >= 2010
            && year <= 2020;
        public static bool isBYRvalid(string value) =>
            int.TryParse(value, out int year)
            && year >= 1920
            && year <= 2002;
    }
}
