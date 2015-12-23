using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    public class DayTwo : IDayProblem
    {
        public int SolvePartOne(string input)
        {
            string[] dimensionSet = File.ReadAllLines(input);
            int totalArea = 0;
            foreach(var dimensions in dimensionSet)
            {
                string[] lwh = dimensions.Split('x');

                if (lwh.Length != 3)
                    continue;

                totalArea += CalculateSurfaceArea(int.Parse(lwh[0]), int.Parse(lwh[1]), int.Parse(lwh[2]));
                totalArea += CalculateSmallestSideArea(int.Parse(lwh[0]), int.Parse(lwh[1]), int.Parse(lwh[2]));
            }

            return totalArea;
        }

        public int SolvePartTwo(string input)
        {
            string[] dimensionSet = File.ReadAllLines(input);

            int totalLength = 0;

            foreach (var dimensions in dimensionSet)
            {
                string[] lwh = dimensions.Split('x');

                if (lwh.Length != 3)
                    continue;

                totalLength += CalculateSmallestPerimeter(int.Parse(lwh[0]), int.Parse(lwh[1]), int.Parse(lwh[2]));
                totalLength += CalculateCubicFeet(int.Parse(lwh[0]), int.Parse(lwh[1]), int.Parse(lwh[2]));
            }

            return totalLength;
        }

        private static int CalculateSmallestPerimeter(int l, int w, int h)
        {
            int perimeter1 = (2 * l) + (2 * w);
            int perimeter2 = (2 * w) + (2 * h);
            int perimeter3 = (2 * l) + (2 * h);

            return Math.Min(Math.Min(perimeter1, perimeter2), perimeter3);
        }

        private static int CalculateCubicFeet(int l, int w, int h)
        {
            return l * w * h;
        }

        private static int CalculateSurfaceArea(int l, int w, int h)
        {
            return (2 * l * w) + (2 * l * h) + (2 * h * w);
        }

        private static int CalculateSmallestSideArea(int l, int w, int h)
        {
            int area1 = l * w;
            int area2 = l * h;
            int area3 = h * w;

            return Math.Min(Math.Min(area1, area2), area3);
            
        }
    }
}
