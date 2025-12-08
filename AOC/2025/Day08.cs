using AdventOfCodeSupport;
using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;

namespace AOC._2025
{
    public class Day08 : AdventBase
    {
        protected override object InternalPart1()
        {
            int answer = 0;
            
            var points = new List<Point>();

            // Parse input into points
            foreach (var line in Input.Lines)
            {
                var split = line.Split(',');
                int x = int.Parse(split[0]);
                int y = int.Parse(split[1]);
                int z = int.Parse(split[2]);
                points.Add(new Point(x, y, z));
            }

            // Calculate distances between all points
            var distances = new Dictionary<(Point, Point), double>();

            foreach (var pointA in points)
            {
                foreach (var pointB in points)
                {
                    if(pointA.Equals(pointB) || distances.ContainsKey((pointA, pointB)) || distances.ContainsKey((pointB, pointA)))
                    {
                        continue;
                    }
                    double distance = EuclideanDistance(pointA, pointB);
                    distances.Add((pointA, pointB), distance);
                }
            }

            // Sort distances
            distances = distances
                .OrderBy(kv => kv.Value)
                .ToDictionary(kv => kv.Key, kv => kv.Value);

            // Connect the circuits
            var circuits = new List<HashSet<Point>>();
            var connect = 1000;

            foreach (var distance in distances)
            {
                if(connect == 0) break;

                var pointA = distance.Key.Item1;
                var pointB = distance.Key.Item2;

                var circuitA = circuits.FirstOrDefault(c => c.Contains(pointA));
                var circuitB = circuits.FirstOrDefault(c => c.Contains(pointB));

                if (circuitA == null && circuitB == null)
                {
                    circuits.Add(new HashSet<Point> { pointA, pointB });
                }
                else if (circuitA != null && circuitB == null)
                {
                    circuitA.Add(pointB);
                }
                else if (circuitA == null && circuitB != null)
                {
                    circuitB.Add(pointA);
                }
                else if (circuitA != null && circuitB != null && !circuitA.SetEquals(circuitB))
                {
                    circuitA.UnionWith(circuitB);
                    circuits.Remove(circuitB);
                }
                connect--;
                
            }

            answer = circuits
                .Select(inner => inner.Count)
                .OrderByDescending(count => count)
                .Take(3)
                .Aggregate(1, (prod, count) => prod * count);

            return answer;
        }

        protected override object InternalPart2()
        {
            int answer = 0;

            foreach (var line in Input.Lines)
            {

            }

            return answer;
        }

        public struct Point
        {
            public int X;
            public int Y;
            public int Z;
            public Point(int x, int y, int z)
            {
                X = x;
                Y = y;
                Z = z;
            }

            public override bool Equals([NotNullWhen(true)] object? obj)
            {
                return base.Equals(obj);
            }

            public override string ToString() => $"({X}, {Y}, {Z})";
        }

        public double EuclideanDistance(Point a, Point b)
        {
            double distance = (double)Math.Sqrt(Math.Pow(b.X - a.X, 2) + Math.Pow(b.Y - a.Y, 2) + Math.Pow(b.Z - a.Z, 2));
            return Math.Round(distance, 2);
        }
    }
}
