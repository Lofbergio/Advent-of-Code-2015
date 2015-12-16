#region

using System;
using System.Diagnostics;
using System.IO;
using System.Linq;

#endregion

namespace Day3
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            string input;
            Console.Write("Todays input:");

            using (var fs = new StreamReader(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\Inputs\Day3.txt")))
                input = fs.ReadToEnd();

            Debug.Assert(!string.IsNullOrWhiteSpace(input), "input != null nor whitespace");
            Console.WriteLine(input);
            Console.WriteLine("------- End of daily input -------");

            var coordSystem = new CoordinateSystem(false);
            coordSystem.Initialize(input);

            if (coordSystem.Initialized)
            {
                var distictCoords = coordSystem.Coordinates.Distinct().ToList();

                Console.WriteLine($"Santa gives {distictCoords.Count} houses at least one present.");
            }

            var coordSystemWithRobo = new CoordinateSystem(true);
            coordSystemWithRobo.Initialize(input);

            if (coordSystemWithRobo.Initialized)
            {
                var distictCoords = coordSystemWithRobo.Coordinates.Distinct().ToList();

                Console.WriteLine($"Santa and Robo-Santa gives {distictCoords.Count} houses at least one present.");
                Console.ReadKey();
            }

        }
    }
}