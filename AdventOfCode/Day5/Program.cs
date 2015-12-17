#region

using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

#endregion

namespace Day5
{
    internal static class Program
    {
        [STAThread]
        private static void Main(string[] args)
        {
            string input;
            Console.Write("Todays input:");

            using (var fs = new StreamReader(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\Inputs\Day5.txt")))
                input = fs.ReadToEnd();

            Debug.Assert(!string.IsNullOrWhiteSpace(input), "input != null nor whitespace");
            Console.WriteLine(input);
            Console.WriteLine("------- End of daily input -------");

            var words = input.Replace("\r", "").Split('\n').ToList();
            var niceWordCount = words.Count(w => IsWordNice(w));

            Console.WriteLine($"Nice words in Santas list: {niceWordCount}");

            /***************
            * Second part! *
            ***************/

            var niceWordCount2 = words.Count(w => IsWordNice(w, true));
            Clipboard.SetText(niceWordCount2.ToString());

            Console.WriteLine($"Nice words in Santas list with Santas new model: {niceWordCount2}");
            Console.Write("The answer has been copied to your clipboard.");
            Console.ReadKey();
        }

        private static bool IsWordNice(string word, bool partTwo = false)
        {
            var bad = new Regex(@"ab|cd|pq|xy");
            var vowels = new Regex(@"[aeiou].*[aeiou].*[aeiou]");
            var doubleLetter = new Regex(@"(.)\1");
            var doubleLetterPair = new Regex(@"(..).*\1");
            var repeat = new Regex(@"(.).\1");

            if (partTwo)
                return doubleLetterPair.Match(word).Success && repeat.Match(word).Success;

            return !bad.Match(word).Success && vowels.Match(word).Success && doubleLetter.Match(word).Success;
        }
    }
}