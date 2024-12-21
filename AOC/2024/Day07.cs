using AdventOfCodeSupport;

namespace AOC._2024;

public class Day07 : AdventBase
{
    protected override object InternalPart1()
    {
        long answer = 0;

        foreach (string line in Input.Lines)
        {
            long testValue = Convert.ToInt64(line.Split(": ")[0]);
            long[] numbers = line.Split(": ")[1].Split(" ").Select(n => Convert.ToInt64(n)).ToArray();

            List<long> results = [numbers[0]];

            for (int i = 0; i < numbers.Length - 1; i++)
            {
                long next = numbers[i + 1];
                var newResults = new List<long>();

                foreach(var result in results)
                {
                    if (result + next <= testValue) newResults.Add(result + next);
                    if (result * next <= testValue) newResults.Add(result * next);
                }

                if (newResults.Count == 0) break;
                results = newResults;
            }

            if (results.Contains(testValue)) answer+= testValue;
        }

        return answer;
    }

    protected override object InternalPart2()
    {
        long answer = 0;

        foreach (string line in Input.Lines)
        {
            long testValue = Convert.ToInt64(line.Split(": ")[0]);
            long[] numbers = line.Split(": ")[1].Split(" ").Select(n => Convert.ToInt64(n)).ToArray();

            List<long> results = [numbers[0]];

            for (int i = 0; i < numbers.Length - 1; i++)
            {
                long next = numbers[i + 1];
                var newResults = new List<long>();

                foreach (var result in results)
                {
                    if (result + next <= testValue) newResults.Add(result + next);
                    if (result * next <= testValue) newResults.Add(result * next);
                    if (long.Parse($"{result.ToString()}{next.ToString()}") <= testValue) newResults.Add(long.Parse($"{result.ToString()}{next.ToString()}"));
                }

                if (newResults.Count == 0) break;
                results = newResults;
            }

            if (results.Contains(testValue)) answer += testValue;
        }

        return answer;
    }
}