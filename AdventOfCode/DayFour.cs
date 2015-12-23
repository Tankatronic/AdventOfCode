using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace AdventOfCode
{
    public class DayFour : IDayProblem
    {
        public int SolvePartOne(string input)
        {
            bool done = false;
            int missingSecret = 0;
            var md5 = MD5.Create();

            while (!done)
            {
                byte[] hash = md5.ComputeHash(Encoding.UTF8.GetBytes(input + missingSecret));

                int consecutiveZeros = 0;
                foreach (byte hashPart in hash)
                {
                    if (consecutiveZeros != 4 && hashPart.ToString("x2") == "00")
                    {
                        consecutiveZeros += 2;
                    }
                    else if (consecutiveZeros == 4 && hashPart.ToString("X2").StartsWith("0"))
                    {
                        md5.Dispose();
                        return missingSecret;
                    }
                    else
                        break;
                }
                missingSecret++;
            }
            return 0;
        }

        public int SolvePartTwo(string input)
        {
            bool done = false;
            int missingSecret = 0;
            var md5 = MD5.Create();

            while (!done)
            {
                byte[] hash = md5.ComputeHash(Encoding.UTF8.GetBytes(input + missingSecret));

                int consecutiveZeros = 0;
                foreach (byte hashPart in hash)
                {
                    if (hashPart.ToString("x2") == "00")
                    {
                        consecutiveZeros += 2;

                        if(consecutiveZeros == 6)
                        {
                            md5.Dispose();
                            return missingSecret;
                        }
                    }                   
                    else
                        break;
                }
                missingSecret++;
            }
            return 0;
        }

    }
}
