using AdventOfCodeSupport;

namespace AOC._2025
{
    public class Day08 : AdventBase
    {
        protected override object InternalPart1()
        {
            int answer = 0;

            var points = GetPoints(Input.Lines);

            Dictionary<(Point3D, Point3D), double> sortedDistances = GetSortedDistances(points);

            var circuits = new List<HashSet<Point3D>>();
            var connect = 10;

            foreach (var distance in sortedDistances)
            {
                if (connect == 0) break;

                var pointA = distance.Key.Item1;
                var pointB = distance.Key.Item2;

                var circuitA = circuits.FirstOrDefault(c => c.Contains(pointA));
                var circuitB = circuits.FirstOrDefault(c => c.Contains(pointB));

                if (circuitA == null && circuitB == null)
                {
                    circuits.Add(new HashSet<Point3D> { pointA, pointB });
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

            var points = GetPoints(Input.Lines);

            Dictionary<(Point3D, Point3D), double> sortedDistances = GetSortedDistances(points);

            var circuits = new List<HashSet<Point3D>>();

            foreach (var distance in sortedDistances)
            {
                var pointA = distance.Key.Item1;
                var pointB = distance.Key.Item2;

                var circuitA = circuits.FirstOrDefault(c => c.Contains(pointA));
                var circuitB = circuits.FirstOrDefault(c => c.Contains(pointB));

                if (circuitA == null && circuitB == null)
                {
                    circuits.Add(new HashSet<Point3D> { pointA, pointB });
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

                if (circuitA?.Count == points.Count || circuitB?.Count == points.Count)
                {
                    // Everything is connected
                    answer += pointA.X * pointB.X;
                    break;
                }
            }

            return answer;
        }

        private List<Point3D> GetPoints(string[] lines)
        {
            var points = new List<Point3D>();
            foreach (var line in lines)
            {
                var split = line.Split(',');
                int x = int.Parse(split[0]);
                int y = int.Parse(split[1]);
                int z = int.Parse(split[2]);
                points.Add(new Point3D(x, y, z));
            }
            return points;
        }

        private Dictionary<(Point3D, Point3D), double> GetSortedDistances(List<Point3D> points)
        {
            var distances = new Dictionary<(Point3D, Point3D), double>();

            foreach (var pointA in points)
            {
                foreach (var pointB in points)
                {
                    if (pointA.Equals(pointB) || distances.ContainsKey((pointA, pointB)) || distances.ContainsKey((pointB, pointA)))
                    {
                        continue;
                    }
                    double distance = EuclideanDistance(pointA, pointB);
                    distances.Add((pointA, pointB), distance);
                }
            }

            distances = distances
                .OrderBy(kv => kv.Value)
                .ToDictionary(kv => kv.Key, kv => kv.Value);

            return distances;
        }

        public double EuclideanDistance(Point3D a, Point3D b)
        {
            double distance = (double)Math.Sqrt(Math.Pow(b.X - a.X, 2) + Math.Pow(b.Y - a.Y, 2) + Math.Pow(b.Z - a.Z, 2));
            return Math.Round(distance, 2);
        }
    }
}
