using System.IO;

namespace AdventOfCode
{
    public class DayThree : IDayProblem
    {
        public int SolvePartOne(string input)
        {
            string directionsInput = File.ReadAllText(input);

            int result = 0;
            char[] directions = directionsInput.ToCharArray();
            int[,] houses = new int[directions.Length * 2, directions.Length * 2]; // make sure we don't move out of bounds

            int x, y;
            y = x = directions.Length / 2; // Start in the middle

            // starting house gets one
            houses[x,y]++;
            result++;

            for (int c = 0; c < directions.Length; c++) // We want to start in the middle of this dimensional array
            {
                switch (directions[c])
                {
                    case '<':
                        x--;
                        break;
                    case '>':
                        x++;
                        break;
                    case '^':
                        y++;
                        break;
                    case 'v':
                        y--;
                        break;
                }

                houses[x, y]++;

                if (houses[x, y] == 1)
                    result++;
            }

            return result;
        }

        public int SolvePartTwo(string input)
        {
            string directionsInput = File.ReadAllText(input);

            int result = 0;
            char[] directions = directionsInput.ToCharArray();
            int[,] houses = new int[directions.Length * 2, directions.Length * 2]; // make sure we don't move out of bounds

            int x, y, a, b;
            x = y = a = b = directions.Length / 2; // Start in the middle
            
            // starting house gets two
            houses[x, y]++;
            houses[x, y]++;
            result++;

            for (int c = 0; c < directions.Length; c++) 
            {
                switch (directions[c])
                {
                    case '<':
                        if (c % 2 == 0)
                            x--;
                        else
                            a--;
                        break;
                    case '>':
                        if (c % 2 == 0)
                            x++;
                        else
                            a++;
                        break;
                    case '^':
                        if (c % 2 == 0)
                            y++;
                        else
                            b++;
                        break;
                    case 'v':
                        if (c % 2 == 0)
                            y--;
                        else
                            b--;
                        break;
                }

                if (c % 2 == 0)
                {
                    houses[x, y]++;

                    if (houses[x, y] == 1)
                        result++;
                }
                else
                {
                    houses[a, b]++;

                    if (houses[a, b] == 1)
                        result++;
                }
            }

            return result;
        }
    }
}
