namespace Day3
{
    internal class Coordinate
    {
        public enum SantaOrRobo
        {
            Robo,
            Santa
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = X.GetHashCode();
                hashCode = (hashCode*397) ^ (Y.GetHashCode());
                return hashCode;
            }
        }

        private bool Equals(Coordinate other)
        {
            return X == other.X && Y == other.Y;
        }

        public int X { get; }
        public int Y { get; }
        public SantaOrRobo Type { get; set; }

        public Coordinate(int x, int y, SantaOrRobo type)
        {
            X = x;
            Y = y;
            Type = type;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
                return false;
            if (ReferenceEquals(this, obj))
                return true;
            return obj.GetType() == GetType() && Equals((Coordinate)obj);
        }
    }
}