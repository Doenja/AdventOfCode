using System.Collections;
using System.Text;

namespace AOC.Utils
{
    internal class Grid : IEnumerable
    {
        public int Width;
        public int Height;
        private readonly char[,] _grid;
        public Grid(string[] lines)
        {
            // Create a grid
            Width = lines[0].Length;
            Height = lines.Count();
            _grid = new char[Width, Height];

            // Fill the grid
            int lineNr = 0;
            foreach (var line in lines)
            {
                for (int letter = 0; letter < Width; letter++)
                {
                    _grid[letter, lineNr] = line[letter];
                }
                lineNr++;
            }
        }
        public bool PointExists(Point point)
        {
            return point.x >= 0 && point.y >= 0 && point.x < Width && point.y < Height;

        }
        public char? GetValue(Point point)
        {
            if (!PointExists(point)) return null;
            return _grid[point.x, point.y];
        }

        public void SetValue(Point point, char value)
        {
            if (PointExists(point))
            {
                _grid[point.x, point.y] = value;
            }
        }

        public bool CheckNeighbourValue(Point point, Point direction, char value)
        {
            return GetValue(point.Add(direction)) == value;
        }

        public IEnumerator GetEnumerator()
        {
            for (int y = 0; y < Width; y++)
            {
                for (int x = 0; x < Height; x++)
                {
                    yield return new Point(x, y);
                }
            }

        }

        internal Point FirstOrDefault(Func<Point, bool> check)
        {
            foreach (Point c in this)
            {
                if (check(c))
                {
                    return c;
                }
            }
            return new Point(0, 0);
        }

        public void Print()
        {
            for (int y = 0; y < Width; y++)
            {
                StringBuilder line = new StringBuilder();
                for (int x = 0; x < Height; x++)
                {
                    line.Append(GetValue(new Point(x, y)));
                }
                Console.WriteLine(line.ToString());
            }
        }
    }
}
