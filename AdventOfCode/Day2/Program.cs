#region

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

#endregion

namespace Day2
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            string input;
            Console.Write("Todays input:");

            using (var fs = new StreamReader(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\Inputs\Day2.txt")))
                input = fs.ReadToEnd();

            Debug.Assert(!string.IsNullOrWhiteSpace(input), "input != null nor whitespace");
            Console.WriteLine(input);
            Console.WriteLine("------- End of daily input -------");

            var dimensions = input.Split('\n').ToList();
            var presents = new List<Present>();
            var totalPaper = 0;
            var totalRibbon = 0;

            // Create a list of new presents from out dimensions
            dimensions.ForEach(x => presents.Add(new Present(x)));

            // Since the presents themselves calculate all the areas we just need to call them
            presents.ForEach(p => totalPaper += (p.SmallestArea + p.TotalArea));
            presents.ForEach(p => totalRibbon += p.RibbonLength);

            Console.WriteLine($"The elves need {totalPaper} square feet of wrapping paper and {totalRibbon} feet of ribbon.");
            Console.ReadKey();
        }
    }
}