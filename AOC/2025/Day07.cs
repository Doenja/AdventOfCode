using AdventOfCodeSupport;

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
            long answer = 0;

            var width = Input.Lines[0].Length;
            var height = Input.Lines.Length;

            var previousRow = new long[width];
            var nextRow = new long[width];

            // Find the start in the first line
            for (int i = 0; i < width; i++)
            {
                char ch = Input.Lines[0][i];
                if (ch == 'S')
                {
                    previousRow[i] = 1;
                    break;
                }
            }

            for (int i = 1; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    char ch = Input.Lines[i][j];
                    long valueAbove = previousRow[j];
                    if (valueAbove == 0) continue;
                    
                    if(ch == '^')
                    {
                        if (j > 0) nextRow[j - 1] += valueAbove;
                        if (j < width - 1) nextRow[j + 1] += valueAbove;
                    }
                    else if (ch == '.')
                    {
                        nextRow[j] += valueAbove;
                    }
                }
                Array.Copy(nextRow, previousRow, width);
                Array.Clear(nextRow, 0, width);
            }

            foreach(var count in previousRow)
            {
                answer += count;
            }

            return answer;
        }
    }
}
