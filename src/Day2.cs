using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Advent
{
    public class Day2
    {
        public static int CountValidPasswordsPolicy1()
        {
            var inputRows = File.ReadAllLines(@"inputs\day02.txt").ToList();
           
            return inputRows.Count(IsValidPassword1);
        }

        public static bool IsValidPassword1(string inputRow)
        {
            var split = inputRow.Split(':');
            var policy = split[0];
            var policyRange = policy.Split(" ")[0];
            var policyLow = int.Parse(policyRange.Split("-")[0]);
            var policyHigh = int.Parse(policyRange.Split("-")[1]);
            var policyLetter = policy.Split(" ")[1][0];
            var password = split[1];

            var letterCount = password.Count(l => l == policyLetter);

            return letterCount >= policyLow && letterCount <= policyHigh;
        }

        public static int CountValidPasswordsPolicy2()
        {
            var inputRows = File.ReadAllLines(@"inputs\day02.txt");
            var validCount = 0;
            foreach (var inputRow in inputRows)
            {
                if (IsValidPassword2(inputRow))
                {
                    validCount++;
                }
            }

            return validCount;
        }

        public static bool IsValidPassword2(string inputRow)
        {
            var split = inputRow.Split(':');
            var policy = split[0];
            var policyRange = policy.Split(" ")[0];
            var firstPosition = int.Parse(policyRange.Split("-")[0]);
            var secondPosition = int.Parse(policyRange.Split("-")[1]);
            var policyLetter = policy.Split(" ")[1][0];
            var password = split[1].Trim();

            return (password[firstPosition - 1] == policyLetter) ^ (password[secondPosition - 1] == policyLetter);
        }
    }
}
