using AdventOfCodeSupport;

namespace AOC._2025
{
    public class Day09 : AdventBase
    {
        protected override object InternalPart1()
        {
            List<Point2D> redTiles = getRedTiles(Input.Lines);

            long largestRectangle = 0;

            for (int i = 0; i < redTiles.Count; i++)
            {
                for (int j = i + 1; j < redTiles.Count; j++)
                {
                    var tile1 = redTiles[i];
                    var tile2 = redTiles[j];

                    var dx = Math.Abs((long)tile1.X - tile2.X) + 1;
                    var dy = Math.Abs((long)tile1.Y - tile2.Y) + 1;

                    long area = dx * dy;
                    if (area > largestRectangle)
                    {
                        largestRectangle = area;
                    }
                }
            }

            return largestRectangle;
        }


        protected override object InternalPart2()
        {
            List<Point2D> redTiles = getRedTiles(Input.Lines);
            var rectangles = new HashSet<(Point2D, Point2D)>();
            long largestRectangle = 0;

            for (int i = 0; i < redTiles.Count; i++)
            {
                for (int j = i + 1; j < redTiles.Count; j++)
                {
                    var tile1 = redTiles[i];
                    var tile2 = redTiles[j];

                    var dx = Math.Abs((long)tile1.X - tile2.X) + 1;
                    var dy = Math.Abs((long)tile1.Y - tile2.Y) + 1;
                    long area = dx * dy;

                    if (area < largestRectangle)
                    {
                        continue;
                    }

                    var rectangle = (tile1, tile2);
                    if (insidePolygon(rectangle, redTiles))
                    {
                        largestRectangle = area;
                    }

                }
            }
            return largestRectangle;
        }

        private List<Point2D> getRedTiles(string[] lines)
        {
            var redTiles = new List<Point2D>();

            foreach (var ch in lines)
            {
                var split = ch.Split(',');
                var point = new Point2D(int.Parse(split[0]), int.Parse(split[1]));
                redTiles.Add(point);
            }

            return redTiles;
        }

        private bool insidePolygon((Point2D, Point2D) rectangle, List<Point2D> polygonPoints)
        {
            var minX = Math.Min(rectangle.Item1.X, rectangle.Item2.X);
            var maxX = Math.Max(rectangle.Item1.X, rectangle.Item2.X);
            var minY = Math.Min(rectangle.Item1.Y, rectangle.Item2.Y);
            var maxY = Math.Max(rectangle.Item1.Y, rectangle.Item2.Y);

            Point2D point = new Point2D();
            Point2D nextPoint = new Point2D();

            for (int i = 0; i < polygonPoints.Count; i++)
            {
                point = polygonPoints[i];
                nextPoint = polygonPoints[(i + 1) % polygonPoints.Count];

                if (point.Y == nextPoint.Y) // horizontal line segment
                {
                    var minSegmentX = Math.Min(point.X, nextPoint.X);
                    var maxSegmentX = Math.Max(point.X, nextPoint.X);

                    var yInRange = point.Y > minY && point.Y < maxY;
                    var xCrosses = minSegmentX < maxX && maxSegmentX > minX;

                    if (yInRange && xCrosses)
                    {
                        return false;
                    }
                }
                else // vertical line segment
                {
                    var minSegmentY = Math.Min(point.Y, nextPoint.Y);
                    var maxSegmentY = Math.Max(point.Y, nextPoint.Y);

                    var xInRange = point.X > minX && point.X < maxX;
                    var yCrosses = minSegmentY < maxY && maxSegmentY > minY;

                    if (xInRange && yCrosses)
                    {
                        return false;
                    }
                }
            }

            return true;
        }


    }
}
