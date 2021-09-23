using System;
using System.Collections.Generic;
using System.Numerics;

namespace Day18OperationOrder
{
    class Program
    {
        public static void Main(string[] args)
        {
            Part2 part2 = new Part2();
            Calculator calculator = new Calculator();
            string line;
            List<string> inputdata = new List<string>();
            List<long> Sums = new List<long>();
            BigInteger complete = 0;
            BigInteger completePart2 = 0;

            System.IO.StreamReader file =
                new System.IO.StreamReader(@"C:\Users\DELL\source\repos\Day18OperationOrder\Day18OperationOrder\Input\input.txt");

            while ((line = file.ReadLine()) != null)
            {
                inputdata.Add(line);
            }

            string test = "((2 + 4 * 9) * (6 + 9 * 8 + 6) + 6) + 2 + 4 * 2";
            long te = part2.calc(test);

            foreach (var item in inputdata)
            {
                Sums.Add(part2.calc(item));
                long total = part2.calc(item);
                completePart2 += total;
            }

            foreach (var item in inputdata)
            {
                Sums.Add(calculator.calc(item));
                long total = calculator.calc(item);
                complete += total;
            }


            Console.WriteLine($"Part 1:\t{complete}");
            Console.WriteLine($"Part 2:\t{completePart2}");
        }
    }
}
