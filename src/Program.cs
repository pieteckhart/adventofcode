using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace src
{
    class Program
    {
        static void Main(string[] args)
        {
            int index = 0;
            var expenseReport = File.ReadAllLines(@"inputs\day01.txt").Select(e => new Entry(index++, int.Parse(e))).ToList();

            var product = CreateCombinations(expenseReport, 3)
                .Where(Is2020)
                .First().Product();

            Console.WriteLine(product);
        }

        private static bool Is2020(LinkedNode node) => node.Sum() == 2020;

        private static IEnumerable<LinkedNode> CreateCombinations(IEnumerable<Entry> items, int length)
        {
            if (length == 1)
                return items.Select(item => new LinkedNode { Value = item, Next = null });

            return from a in items
                   from b in CreateCombinations(items, length - 1)
                   where !a.Equals(b.Value)
                   orderby a, b.Value
                   select new LinkedNode { Value = a, Next = b };
        }

        public class LinkedNode
        {
            public Entry Value { get; set; }
            public LinkedNode Next { get; set; }

            public override string ToString() => $"{Value} - {Next}";

            public int Sum() => Next != null ? Value.Value + Next.Sum() : Value.Value;
            public int Product() => Next != null ? Value.Value * Next.Product() : Value.Value;
        }

        public class Entry : IComparable
        {
            public Entry(int index, int value)
            {
                Index = index;
                Value = value;
            }

            public int Index { get; }
            public int Value { get; }

            public int CompareTo(object obj) => Value.CompareTo(((Entry)obj).Value);

            public override bool Equals(object obj) => ((Entry)obj).Index.Equals(Index);

            public override string ToString() => $"#{Index}: {Value}";
        }
    }
}
