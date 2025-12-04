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
                    // Only look at the rolls of paper
                    if(lines[i][j] == '.')
                    {
                        continue;
                    }

                    var id = (x: j, y: i);   
                    if (!adjacents.ContainsKey(id))
                    {
                        adjacents[id] = new List<(int, int)>();
                    }
                    FillAdjacentList(id, adjacents[id], (lines[i].Length - 1, lines.Length - 1));


                    int counter = 0;
                    foreach (var adjacent in adjacents[id])
                    {
                        if (counter == 4)
                        {
                            break;
                        }
                        if (lines[adjacent.y][adjacent.x] == '@')
                        {
                            counter++;
                        }
                    }
                    if(counter < 4)
                    {
                        answer++;
                    }
              
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

        public void FillAdjacentList((int x, int y) id, List<(int, int)> adjacentList, (int x, int y) gridSize)
        {

            for (int i = id.x -1; i < id.x + 2; i++)
            {
                if(i < 0 || i > gridSize.x)
                {
                    continue;
                }

                for (int j = id.y - 1; j < id.y + 2; j++)
                {
                    if ((i == id.x && j == id.y) || j < 0 || j > gridSize.y)
                    {
                        continue;
                    }
                    adjacentList.Add((i, j));
                }
            }
        }

    }
}
