using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    public static class DayFactory
    {
        public static IDayProblem CreateDayProblem(string day)
        {
            try
            {
                TextInfo info = new CultureInfo("en-US", false).TextInfo;
                Type t = Type.GetType($"AdventOfCode.Day{info.ToTitleCase(day)}");

                if (t == null)
                    return null;

                return (IDayProblem)Activator.CreateInstance(t);
            }
            catch (TypeInitializationException)
            {
                Console.WriteLine("Unknown day entered");
                return null;
            }
        }
    }
}
