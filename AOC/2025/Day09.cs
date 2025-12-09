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

            for (int i = 0; i < redTiles.Count; i++)
            {
                if (i == redTiles.Count - 1)
                {
                    // Connect the last redTIle to the first
                    break;
                }

                var tile = redTiles[i];
                var nextTile = redTiles[i + 1];

                if (tile.X == nextTile.X)
                {

                }
                else if (tile.Y == nextTile.Y)
                {

                }
            }

            return 0;

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


    }
}
