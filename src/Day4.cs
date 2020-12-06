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
        private string input;

        public APS(string input)
        {
            this.input = input;
        }

        public int GetValidCount()
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

            return      passport.byr != null 
                     && passport.iyr != null
                     && passport.eyr != null
                     && passport.hgt != null 
                     && passport.hcl != null 
                     && passport.ecl != null 
                     && passport.pid != null 
                ? 1 : 0;
        }
    }
}
