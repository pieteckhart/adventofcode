using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.WebSockets;
using System.Security.Cryptography;
using Advent;
using Xunit;


namespace Test
{
    public class Day7Tests
    {
        [Fact]
        public void ScanAll()
        {
            var rules = File.ReadAllText(@"inputs\day07.txt");
            var scanner = new LuggageScanner(rules);
            var outcome = scanner.Scan("shiny gold");
            Assert.Equal(112, outcome);
        }

        [Fact]
        public void FindBagsInside()
        {
            var rules = File.ReadAllText(@"inputs\day07.txt");
            var scanner = new LuggageScanner(rules);
            var outcome = scanner.CountBags();
            Assert.Equal(6260, outcome);
        }

        [Fact]
        public void FindBagsInsideExample()
        {
            var rules = (@"light red bags contain 1 bright white bag, 2 muted yellow bags.
dark orange bags contain 3 bright white bags, 4 muted yellow bags.
bright white bags contain 1 shiny gold bag.
muted yellow bags contain 2 shiny gold bags, 9 faded blue bags.
shiny gold bags contain 1 dark olive bag, 2 vibrant plum bags.
dark olive bags contain 3 faded blue bags, 4 dotted black bags.
vibrant plum bags contain 5 faded blue bags, 6 dotted black bags.
faded blue bags contain no other bags.
dotted black bags contain no other bags.");
            var scanner = new LuggageScanner(rules);
            var outcome = scanner.CountBags();
            Assert.Equal(32, outcome);
        }





    }
}
