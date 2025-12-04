using AdventOfCodeSupport;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.Diagnostics.Tracing.Parsers.MicrosoftWindowsWPF;
using System.Numerics;

namespace AOC._2025
{
    public class Day04 : AdventBase
    {
        protected override object InternalPart1()
        {
            int answer = 0;
            var adjacents = new Dictionary<(int x, int y), List<(int x, int y)>>();
            var lines = Input.Lines;

            for (int i = 0; i < lines.Length; i++)
            {
                for (int j = 0; j < lines[i].Length; j++)
                {
                    if(lines[i][j] == '.')
                    {
                        continue;
                    }

                    int adjacentRolls = 0;
                    var id = (x: j, y: i);   
                    adjacents[id] = GetAdjacents(j, i, lines[0].Length, lines.Length).ToList();

                    foreach (var (x, y) in adjacents[id])
                    {
                        if (adjacentRolls == 4)
                        {
                            break;
                        }
                        if (lines[y][x] == '@')
                        {
                            adjacentRolls++;
                        }
                    }
                    if (adjacentRolls < 4)
                    {
                        answer++;
                    }
                }
            }

            return answer;
        }

        protected override object InternalPart2()
        {
            int answer = 0;
            var adjacents = new Dictionary<(int x, int y), List<(int x, int y)>>();
            var lines = Input.Lines;

            // Make a dictionary of all roll coordinates and their adjacent coordinates
            for (int i = 0; i < lines.Length; i++)
            {
                for (int j = 0; j < lines[i].Length; j++)
                {
                    if (lines[i][j] == '.')
                    {
                        continue;
                    }

                    var id = (x: j, y: i);
                    adjacents[id] = GetAdjacents(j, i, lines[0].Length, lines.Length).ToList();
                }
            }

            var canRemoveRolls = true;

            while (canRemoveRolls)
            {
                var rollsToRemove = new List<(int x, int y)>();

                foreach ((int x, int y) id in adjacents.Keys)
                {
                    int adjacentRolls = 0;

                    foreach ((int x, int y) adjacentId in adjacents[id])
                    {
                        if (lines[adjacentId.y][adjacentId.x] == '@' && adjacents.ContainsKey(adjacentId))
                        {
                            adjacentRolls++;
                        }
                    }

                    if (adjacentRolls < 4)
                    {
                        rollsToRemove.Add(id);
                    }
                }

                if(rollsToRemove.Count > 0)
                {
                    answer += rollsToRemove.Count;
                    rollsToRemove.ForEach(id => adjacents.Remove(id));

                } else
                {
                    canRemoveRolls = false;
                }
            }

            return answer;
        }

        public IEnumerable<(int x, int y)> GetAdjacents(int x, int y, int width, int height)
        {
            for (int dx = -1; dx <= 1; dx++)
            {
                for (int dy = -1; dy <= 1; dy++)
                {
                    if (dx == 0 && dy == 0)
                    {
                        continue; // Skip self
                    }

                    int newX = x + dx;
                    int newY = y + dy;

                    if (newX >= 0 && newX < width && newY >= 0 && newY < height)
                    {
                        yield return (newX, newY);
                    }
                }
            }
        }
           
    }
}
