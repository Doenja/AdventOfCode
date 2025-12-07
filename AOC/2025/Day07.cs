using AdventOfCodeSupport;
using System.Text.RegularExpressions;

namespace AOC._2025
{
    public class Day07 : AdventBase
    {
        protected override object InternalPart1()
        {
            int answer = 0;
            var beamIndices = new HashSet<int>();

            foreach (var line in Input.Lines)
            {
                for (int i = 0; i < line.Length; i++)
                {
                    char ch = line[i];
                    if(ch == 'S')
                    {
                        beamIndices.Add(i);
                    }

                    if (ch == '^' && beamIndices.Contains(i))
                    {
                        beamIndices.Remove(i); // Beam does not continue downwards for this index
                        if (i > 0) beamIndices.Add(i - 1); // It continues to the left
                        if (i < line.Length - 1) beamIndices.Add(i + 1); // It continues to the right
                        answer++; // Count the split
                    }
                }            
            }
            return answer;
        }

        protected override object InternalPart2()
        {
            int answer = 0;

            var width = Input.Lines[0].Length;
            var height = Input.Lines.Length;

            var previousRow = new int[width];
            var currentRow = new int[width];

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    char ch = Input.Lines[i][j];
                    if (ch == 'S')
                    {
                        currentRow[j] = 1; // Start point
                        continue;
                    }

                    int countsAboveMe = i > 0 ? previousRow[j] : 0;

                    if (countsAboveMe == 0) continue;
                 
                    if (ch == '^')
                    {
                        if (j > 0) currentRow[j - 1] += countsAboveMe;
                        if (j < width - 1) currentRow[j + 1] += countsAboveMe;
                    } 
                    else
                    {
                        currentRow[j] = previousRow[j];
                    }
                }
                previousRow = currentRow;
                currentRow = new int[width];
            }

            foreach(var count in currentRow)
            {
                answer += count;
            }

            return answer;
        }
    }
}
