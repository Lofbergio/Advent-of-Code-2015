#region

using System;
using System.Diagnostics;
using System.IO;
using System.Linq;

#endregion

namespace Day1
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            string input;
            Console.Write("Todays input:");

            // Console.ReadLine has an arbitrary 264 char limit so we have to get the information from a different source.
            // Using a webclient does not work either since the input is per-user so we cant access it without authentication
            using (var fs = new StreamReader(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\Inputs\Day1.txt")))
                input = fs.ReadToEnd();

            Debug.Assert(input != null, "input != null");
            Console.WriteLine(input);

            var floorsUp = input.Count(_ => _ == '(');
            var floorsDown = input.Count(_ => _ == ')');

            var floor = (0 + floorsUp) - floorsDown;

            Console.WriteLine("Santa ends up on Floor {0}", floor);

            /***************
            * Second part! *
            ***************/

            var floorReachedBasement = 0;
            var currentFloor = 0;
            for (var index = 0; index < input.Count(); index++)
            {
                var character = input[index];
                switch (character)
                {
                    case '(':
                        currentFloor++;
                        break;

                    case ')':
                        currentFloor--;
                        break;
                }

                if (currentFloor == -1 && floorReachedBasement == 0)
                    floorReachedBasement = index + 1; // +1 since the instructions start from 1.. for some reason
            }

            Console.WriteLine("Santa reaches the basement first time at {0}", floorReachedBasement);
            Console.ReadKey();
        }
    }
}