using System.Xml.Linq;

namespace AOC.Utils
{
    internal class Point
    {
        public int x = 0;
        public int y = 0;

        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public Point Add(Point p)
        {
            return new Point(x + p.x, y + p.y);
        }
        public Point Subtract(Point p)
        {
            return new Point(x - p.x, y - p.y);
        }

        public override string ToString()
        {
            return $"{x}, {y}";
        }
    }
}
