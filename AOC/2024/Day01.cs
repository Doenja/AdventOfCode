using System.ComponentModel;
using AdventOfCodeSupport;

namespace AOC._2024;

public class Day01 : AdventBase
{
    protected override object InternalPart1()
    {
        int answer = 0;
        int length = Input.Lines.Length;

        // Make two arrays
        var leftNrs = new int[length];
        var rightNrs = new int[length];

        splitInput(length, leftNrs, rightNrs);

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
        int length = Input.Lines.Length;

        var leftNrs = new int[length];
        var rightNrs = new int[length];

        splitInput(length, leftNrs, rightNrs);

        // Make a dict where each key is an int from the rightNrs
        // and each value its occurance in the rightNrs
        var occurance = new Dictionary<int, int>();
        foreach (var nr in rightNrs)
        {
            if (occurance.ContainsKey(nr))
            {
                occurance[nr]++;
            } else
            {
                occurance[nr] = 1;
            }
        }

        // For each nr in the leftNrs
        // add its value times its occurance to answer
        foreach (var nr in leftNrs) 
        {
            if (occurance.ContainsKey(nr))
            {
                answer += nr * occurance[nr];
            } 
        }

        return answer;
    }

    internal void splitInput(int length, int[] leftNrs, int[] rightNrs)
    {
        // Make two lists


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
            if (parsedR)
            {
                rightNrs[i] = right;
            }
        }
    }
}