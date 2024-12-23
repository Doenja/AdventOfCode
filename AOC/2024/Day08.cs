
using System.Runtime.InteropServices;
using AdventOfCodeSupport;
using AOC.Utils;

namespace AOC._2024;

public class Day08 : AdventBase
{
    protected override object InternalPart1()
    {
        Grid grid = new Grid(Input.Lines);
        var antennas = new Dictionary<char, List<Point>>();

        foreach (Point point in grid)
        {
            var ch = grid.GetValue(point);
            if (ch == null || ch == '.' ) continue;

            if (antennas.ContainsKey((char)ch))
            {
                antennas[(char)ch].Add(point);
            }
            else
            {
                antennas.Add((char)ch, new List<Point>([point]));
            }
        }

        var antinodes = new HashSet<int>();

        foreach (var ch in antennas.Keys)
        {
            foreach (var point1 in antennas[ch])
            {
                foreach (var point2 in antennas[ch])
                {
                    if (point1 == point2) continue;

                    Point diff = point1.Subtract(point2);

                    Point anti1 = point1.Add(diff);
                    Point anti2 = point2.Subtract(diff);

                    if (grid.PointExists(anti1)) antinodes.Add(hashTwo(anti1.x, anti1.y));
                    if (grid.PointExists(anti2)) antinodes.Add(hashTwo(anti2.x, anti2.y));
                }
            }
        }
        return antinodes.Count;
    }

    protected override object InternalPart2()
    {
        Grid grid = new Grid(Input.Lines);
        var antennas = new Dictionary<char, List<Point>>();

        foreach (Point point in grid)
        {
            var ch = grid.GetValue(point);
            if (ch == null || ch == '.') continue;

            if (antennas.ContainsKey((char)ch))
            {
                antennas[(char)ch].Add(point);
            }
            else
            {
                antennas.Add((char)ch, new List<Point>([point]));
            }
        }

        var antinodes = new HashSet<int>();

        foreach (var ch in antennas.Keys)
        {
            foreach (var point1 in antennas[ch])
            {
                foreach (var point2 in antennas[ch])
                {
                    if (point1 == point2) continue;

                    var cur1 = new Point(point1.x, point1.y);
                    var cur2 = new Point(point2.x, point2.y);
                    Point diff = point1.Subtract(point2);

                    while (grid.PointExists(cur1))
                    {
                        antinodes.Add(hashTwo(cur1.x, cur1.y));
                        cur1 = cur1.Add(diff);
                    }

                    while (grid.PointExists(cur2))
                    {
                        antinodes.Add(hashTwo(cur2.x, cur2.y));
                        cur2 = cur2.Subtract(diff);
                    }
                }
            }
        }
        return antinodes.Count;
    }

    internal int hashTwo(int a, int b)
    {
        return a >= b ? a * a + a + b : a + b * b;
    }

}

