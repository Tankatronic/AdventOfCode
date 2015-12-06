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

                int day = 0;

                if (int.TryParse(daySplit[1], out day) == false)
                {
                    Console.WriteLine("Please specify a valid day.");
                    return;
                }

                switch (day)
                {
                    case 1:
                        if (args.Length > 1 && File.Exists(args[1]))
                        {
                            int result = DayOne.SolvePartOne(args[1]);
                            Console.WriteLine($"Result for Part 1: {result}");

                            result = DayOne.SolvePartTwo(args[1]);
                            Console.WriteLine($"Result for Part 2: {result}");

                        }
                        else
                            Console.WriteLine("File not found");
                        break;
                    case 2:
                        if (args.Length > 1 && File.Exists(args[1]))
                        {
                            string[] dimensionSet = File.ReadAllLines(args[1]);
                            int result = DayTwo.SolvePartOne(dimensionSet);
                            Console.WriteLine($"Result for Part 1: {result}");

                            result = DayTwo.SolvePartTwo(dimensionSet);
                            Console.WriteLine($"Result for Part 2: {result}");

                        }
                        break;
                    case 3:
                        if (args.Length > 1 && File.Exists(args[1]))
                        {
                            string directions = File.ReadAllText(args[1]);
                            int result = DayThree.SolvePartOne(directions);
                            Console.WriteLine($"Result for Part 1: {result}");
                            
                            result = DayThree.SolvePartTwo(directions);
                            Console.WriteLine($"Result for Part 2: {result}");
                            

                        }
                        break;
                    default:
                        Console.WriteLine("Day not implemented");
                        break;
                }
            
            }
        }
    }
}
