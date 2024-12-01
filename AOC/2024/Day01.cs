using AdventOfCodeSupport;

namespace AOC._2024;

public class Day01 : AdventBase
{
    protected override object InternalPart1()
    {
        int answer = 0;
        int length = Input.Lines.Length;

        // Make two lists
        var leftNrs = new int[length];
        var rightNrs = new int[length];

        for (int i = 0; i < length; i++)
        {
            var split = Input.Lines[i].Split("   ");

            int left;
            var parsedL = int.TryParse(split[0], out left);
            if (parsedL)
            {
                leftNrs[i] = left;
            }

            int right;
            var parsedR = int.TryParse(split[1], out right);
            if(parsedR)
            {
                rightNrs[i] = right;
            }
        }


        // Sort them
        Array.Sort(leftNrs);
        Array.Sort(rightNrs);

        // Loop through both and add the difference of each pair to the answer
        for (int i = 0; i < length; i++)
        {
            answer += Math.Abs(leftNrs[i] - rightNrs[i]);
        }

        return answer;
    }

    protected override object InternalPart2()
    {
        int answer = 0;

        foreach (var line in Input.Lines)
        {
            //
        }

        return answer;
    }
}