#region

using System;
using System.Collections.Generic;
using System.Linq;

#endregion

namespace Day2
{
    internal class Present
    {
        // ReSharper disable MemberCanBePrivate.Global
        public int Length { get; }
        public int Width { get; }
        public int Height { get; }

        public int TotalArea { get; private set; }
        public int SmallestArea { get; private set; }

        public int RibbonLength { get; private set; }
        // ReSharper restore MemberCanBePrivate.Global

        public Present(string dimensions)
        {
            var split = dimensions.Split('x');

            Length = Convert.ToInt32(split[0]);
            Width = Convert.ToInt32(split[1]);
            Height = Convert.ToInt32(split[2]);

            var sides = new List<int>
                        {
                            Length*Width,
                            Width*Height,
                            Height*Length
                        };

            sides.ForEach(x => TotalArea += 2*x);
            SmallestArea = sides.Min();

            var areasForRibbon = new List<int>
                                 {
                                     2*Length + 2*Width,
                                     2*Width + 2*Height,
                                     2*Height + 2*Length
                                 };

            var bowLength = Length*Width*Height;
            RibbonLength = bowLength + areasForRibbon.Min();
        }
    }
}