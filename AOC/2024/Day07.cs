using AdventOfCodeSupport;

namespace AOC._2024;

public class Day07 : AdventBase
{
    protected override object InternalPart1()
    {
        int answer = 0;

        foreach (var line in Input.Lines)
        {
            int testValue = Convert.ToInt32(line.Split(": ")[0]);
            int[] numbers = line.Split(": ")[1].Split(" ").Select(n => Convert.ToInt32(n)).ToArray();

            
        }

        return answer;
    }

    protected override object InternalPart2()
    {
        int answer = 0;


        return answer;
    }


}