#region

using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

#endregion

namespace Day4
{
    internal static class Program
    {
        public static string Md5Hash(string input)
        {
            var inputBytes = Encoding.ASCII.GetBytes(input);
            var hash = MD5.Create().ComputeHash(inputBytes).ToList();
            var hashString = "";

            hash.ForEach(b => hashString += b.ToString("X2"));

            return hashString;
        }

        private static void Main(string[] args)
        {
            string input;
            Console.Write("Todays input:");

            using (var fs = new StreamReader(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\Inputs\Day4.txt")))
                input = fs.ReadToEnd();

            Debug.Assert(!string.IsNullOrWhiteSpace(input), "input != null nor whitespace");
            Console.WriteLine(input);
            Console.WriteLine("------- End of daily input -------");
            

            var resultHash = "";
            var inputCounter = 0;

            while (!resultHash.StartsWith("00000"))
            {
                resultHash = Md5Hash(input + ++inputCounter);
                Console.Write("\rCurrent number: {0}", inputCounter);
            }

            Console.WriteLine($"\nWith the key {input + inputCounter} we get the hash with five leading zeroes {resultHash}.");


            /***************
            * Second part! *
            ***************/

            inputCounter = 0;

            while (!resultHash.StartsWith("000000"))
            {
                resultHash = Md5Hash(input + ++inputCounter);
                Console.Write("\rCurrent number: {0}", inputCounter);
            }

            Console.WriteLine($"\nWith the key {input + inputCounter} we get the hash with six leading zeroes {resultHash}.");
            Console.ReadKey();
        }
    }
}