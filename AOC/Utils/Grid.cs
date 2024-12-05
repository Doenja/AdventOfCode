using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

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

        public char? GetValue(Point point)
        {
            if (point.x < 0 || point.y < 0 || point.x >= Width || point.y >= Height) return null;
            return _grid[point.x, point.y];
        }

        public Point GetNeighbour(Point point, Point direction)
        {
            return point.Add(direction);
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
    }
}
