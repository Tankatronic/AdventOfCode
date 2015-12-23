using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace AdventOfCode
{
    public class DayFive : IDayProblem
    {
        private readonly string[] badStrings = { "ab", "cd", "pq", "xy" }; 
        public int SolvePartOne(string input)
        {
            string[] strings = File.ReadAllLines(input);
            int result = 0;
            
            foreach (string currentString in strings)
            {
                int vowelCount = 0;
                char? lastChar = null;
                bool vowelMinMet = false;
                bool hasBadStrings = false;
                bool hasRepeat = false;

                foreach (string badString in badStrings)
                {
                    if (currentString.IndexOf(badString) >= 0)
                    {
                        hasBadStrings = true;
                        break;
                    }
                }

                if (hasBadStrings)
                    continue;

                foreach (char c in currentString.ToCharArray())
                {
                    if (!hasRepeat)
                    {
                        if (c == lastChar)
                            hasRepeat = true;
                        else
                            lastChar = c;
                    }

                    if (!vowelMinMet && IsVowel(c))
                    {
                        vowelCount++;

                        if (vowelCount == 3)
                            vowelMinMet = true;
                    }

                }

                if (vowelMinMet && hasRepeat)
                    result++;
            }
            return result;
        }

        public int SolvePartTwo(string input)
        {
            string[] strings = File.ReadAllLines(input);
            int result = 0;

            foreach (string currentString in strings)
            {
                char? lastChar = null;
                bool hasPair = false;
                bool hasSpacedRepeat = false;

                char[] charArray = currentString.ToCharArray();

                for (int i = 0; i < charArray.Length; i++)
                {
                    if (!hasPair)
                    {
                        if((i + 2) < charArray.Length)
                        {
                            hasPair = currentString.IndexOf($"{charArray[i]}{charArray[i + 1]}", i + 2) >= 0; 
                        }
                    }

                    if (!hasSpacedRepeat)
                    {
                        if ((i + 2) < charArray.Length && charArray[i] == charArray[i + 2])
                            hasSpacedRepeat = true;
                    }

                }

                if (hasPair && hasSpacedRepeat)
                    result++;
            }
            return result;
        }

        private bool IsVowel(char c)
        {
            return "aeiou".IndexOf(c) >= 0;
        }

        
    }
}
