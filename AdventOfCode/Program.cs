using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length > 0 && args[0].ToLower().StartsWith("day="))
            {
                string[] daySplit = args[0].Split('=');

                if (daySplit.Length <= 1)
                {
                    Console.WriteLine("Please specify day");
                    return;
                }

                IDayProblem dayProblem = DayFactory.CreateDayProblem(daySplit[1]);

                if (dayProblem == null)
                {
                    Console.WriteLine("Please specify a valid day.");
                    return;
                }

                int result;
                try
                {
                    result = dayProblem.SolvePartOne(args[1]);
                    Console.WriteLine($"Result for Part 1: {result}");

                    result = dayProblem.SolvePartTwo(args[1]);
                    Console.WriteLine($"Result for Part 2: {result}");
                }
                catch(Exception e)
                {
                    Console.WriteLine("Something went terribly wrong");
                    Console.WriteLine(e.Message);
                    Console.WriteLine(e.StackTrace);
                }
            }
        }
    }
}
