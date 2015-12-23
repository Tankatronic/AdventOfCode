using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    public class DayOne : IDayProblem
    {
        public int SolvePartOne(string input)
        {
            int floor = 0;
            char[] parenInput = File.ReadAllText(input).ToCharArray();

            foreach(char paren in parenInput)
            {
                if (paren == '(')
                    floor++;
                else if (paren == ')')
                    floor--;
            }

            return floor;
        }

        public int SolvePartTwo(string input)
        {
            int floor = 0;
            char[] parenInput = File.ReadAllText(input).ToCharArray();

            for(int i = 0; i < parenInput.Length; i++)
            {
                if (parenInput[i] == '(')
                    floor++;
                else if (parenInput[i] == ')')
                    floor--;

                if (floor == -1)
                    return i + 1;
            }

            return -1;
        }
    }
}
