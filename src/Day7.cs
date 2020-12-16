using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Xsl;

namespace Advent
{
    public class LuggageScanner
    {
        private readonly List<Bag> outerBags = new List<Bag>();

        public LuggageScanner(string input)
        {
            List<(Bag bag, string contents)> rawBagContent = new List<(Bag, string)>();
            var rows = input.Split(Environment.NewLine).ToList();
            var regex = new Regex( "(?<Color>[a-z]+ [a-z]+) bags contain (?<Contents>.+)");
            foreach (var row in rows)
            {
                var outerBagMatch = regex.Match(row);
                var color = outerBagMatch.Groups["Color"].Value;
                var contents = outerBagMatch.Groups["Contents"].Value;
                Bag bag = new Bag
                {
                    Color = color
                };
                rawBagContent.Add((bag, contents));
                outerBags.Add(bag);
            }
            var rawRegex    = new Regex(@"(?<Amount>\d+) (?<Color>[a-z]+ [a-z]+) bags{0,1}");
            
            foreach (var raw in rawBagContent)
            {
                var match = rawRegex.Match(raw.contents);
                while (match.Success)
                {
                    var amount = int.Parse(match.Groups["Amount"].Value);
                    var innerColor = match.Groups["Color"].Value;
                    var outerBag = outerBags.Single(b => b.Color == raw.bag.Color);
                    var innerBag = outerBags.Single(b => b.Color == innerColor);
                    outerBag.BagContent.Add(new InnerBag { Amount = amount, Bag = innerBag });
                    match = match.NextMatch();
                }
            }
        }

        public int CountBags()
        {
            var shinyGold = outerBags.Single(b => b.Color == "shiny gold");

            return shinyGold.NumberOfBagsInside -1;
        }

        public int Scan(string colorToScan)
            => outerBags.Count(b => b.HasBagWithColor("shiny gold"));
    }

    public class Bag
    {
        public string Color { get; set; }
        public List<InnerBag> BagContent { get; set; } = new List<InnerBag>();
        public int NumberOfBagsInside => BagContent.Sum(c => (c.Bag.NumberOfBagsInside*c.Amount))+1;

        public bool HasBagWithColor(string color) => BagContent.Any(c=>c.Bag.Color == color) || BagContent.Any(c => c.Bag.HasBagWithColor(color));

        public override string ToString()
        {
            return $"{Color} ({BagContent.Count})";
        }
    }

    public class InnerBag
    {
        public Bag Bag { get; set; }
        public int Amount { get; set; }

        public override string ToString()
        {
            return $"{Amount}x {Bag.Color}";
        }
    }
}
