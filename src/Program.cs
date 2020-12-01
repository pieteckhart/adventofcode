using System;
using System.IO;
using System.Linq;

namespace src
{
    class Program
    {
        static void Main(string[] args)
        {
            var expenseReport = File.ReadAllLines("input1.txt").Select(i => int.Parse(i)).ToList();

            for (int i = 0; i < expenseReport.Count; i++)
            {
                int entry = expenseReport[i];
                for (int i1 = i+1; i1 < expenseReport.Count; i1++)
                {
                    int otherEntry = expenseReport[i1];
                    for (int i2 = i1 + 1; i2 < expenseReport.Count; i2++)
                    {
                        int anotherEntry = expenseReport[i2];
                        if (entry + otherEntry + anotherEntry == 2020)
                        {
                            Console.WriteLine(entry * otherEntry * anotherEntry);
                            goto hoi;
                        }
                    }
                }
            }
        hoi:
            Console.WriteLine("Klaar");
        }
    }
}
