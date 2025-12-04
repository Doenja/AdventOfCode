using AdventOfCodeSupport;
using System.Numerics;

namespace AOC._2025
{
    public class Day04 : AdventBase
    {
        protected override object InternalPart1()
        {
            int answer = 0;
            var adjacents = new Dictionary<(int, int), List<(int, int)>>();

            for (int i = 0; i < Input.Lines.Length; i++)
            {
                for (int j = 0; j < Input.Lines[i].Length; j++)
                {
                    if(Input.Lines[i][j] == '.')
                    {
                        continue;
                    }

                    var id = (x: i, y: j);   
                    if (!adjacents.ContainsKey(id))
                    {
                        adjacents[id] = new List<(int, int)>();
                    }
                    AddAdjacents(id, Input.Lines[i].Length - 1, Input.Lines.Length - 1, adjacents[id]);

                }
            }

            return answer;
        }

        protected override object InternalPart2()
        {
            long answer = 0;

            foreach(var line in Input.Lines)
            {
           
            }
            return answer;
        }

        public void AddAdjacents((int x, int y) id, int maxX, int maxY, List<(int, int)> adjacentList)
        {
            int startX = id.x == 0 ? 0 : id.x - 1;
            int endX = id.x == maxX ? maxX : id.x + 1;
            int startY = id.y == 0 ? 0 : id.y - 1;
            int endY = id.y == maxY ? maxY : id.y + 1;

            for (int i = startX; i < endX; i++)
            {
                for (int j = startY; j < endY; j++)
                {
                    adjacentList.Add((i, j));
                }
            }
        }

    }
}
