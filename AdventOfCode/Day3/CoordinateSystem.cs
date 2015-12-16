#region

using System.Collections.Generic;
using System.Drawing;

#endregion

namespace Day3
{
    internal class CoordinateSystem
    {
        public bool IsRoboInvolved { get; }
        public bool Initialized { get; private set; }
        public List<Coordinate> Coordinates { get; }

        private Point _santaLocation = new Point(0, 0);
        private Point _roboLocation = new Point(0, 0);

        public CoordinateSystem(bool isRoboInvolved)
        {
            IsRoboInvolved = isRoboInvolved;

            Coordinates = new List<Coordinate>
                          {
                              new Coordinate(0, 0, Coordinate.SantaOrRobo.Santa)
                          };
        }

        public void Initialize(string input)
        {
            Coordinates.Clear();
            Coordinates.Add(new Coordinate(0, 0, Coordinate.SantaOrRobo.Santa));

            if (IsRoboInvolved)
                Coordinates.Add(new Coordinate(0, 0, Coordinate.SantaOrRobo.Robo));

            var santasTurn = true;

            foreach (var character in input)
            {
                switch (character)
                {
                    case '^':
                        if (IsRoboInvolved && !santasTurn)
                        {
                            _roboLocation.Y++;
                            break;
                        }

                        if (santasTurn)
                            _santaLocation.Y++;
                        break;

                    case 'v':
                        if (IsRoboInvolved && !santasTurn)
                        {
                            _roboLocation.Y--;
                            break;
                        }

                        if (santasTurn)
                            _santaLocation.Y--;
                        break;

                    case '>':
                        if (IsRoboInvolved && !santasTurn)
                        {
                            _roboLocation.X++;
                            break;
                        }

                        if (santasTurn)
                            _santaLocation.X++;
                        break;

                    case '<':
                        if (IsRoboInvolved && !santasTurn)
                        {
                            _roboLocation.X--;
                            break;
                        }

                        if (santasTurn)
                            _santaLocation.X--;
                        break;
                }

                Coordinates.Add(new Coordinate(santasTurn ? _santaLocation.X : _roboLocation.X, santasTurn ? _santaLocation.Y : _roboLocation.Y, santasTurn ? Coordinate.SantaOrRobo.Santa : Coordinate.SantaOrRobo.Robo));

                if (IsRoboInvolved)
                    santasTurn = !santasTurn;
            }

            Initialized = true;
        }
    }
}