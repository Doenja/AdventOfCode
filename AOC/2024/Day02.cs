using AdventOfCodeSupport;

namespace AOC._2024;

public class Day02 : AdventBase
{
    protected override object InternalPart1()
    {
        int answer = 0;
        int length = Input.Lines.Length;

        foreach (string line in Input.Lines)
        {
            var numbers = line.Split(' ')?.Select(Int32.Parse)?.ToList();

            if (numbers != null)
            {
                if (isListSafe(numbers)) answer++;
            }
        }
        return answer;
    }

    protected override object InternalPart2()
    {
        int answer = 0;
        int length = Input.Lines.Length;

        foreach (string line in Input.Lines)
        {
            var numbers = line.Split(' ')?.Select(Int32.Parse)?.ToList();

            if (numbers != null)
            {
                if (isListSafe(numbers))
                {
                    answer++;
                }
                else
                {
                    bool isSafe = false;
                    for (int i = 0; i < numbers.Count; i++)
                    {
                        var tempList = new List<int>(numbers);
                        tempList.RemoveAt(i);
                        if (isListSafe(tempList))
                        {
                            isSafe = true;
                            break;
                        }
                    }
                    if (isSafe) answer++;
                }
                ;
            }
        }
        return answer;
    }


    private bool isValidDifference(int n1, int n2)
    {
        return n1 != n2 && Math.Abs(n1 - n2) < 4;
    }

    private bool isIncreasing(int n1, int n2)
    {
        return n2 > n1;
    }

    private bool isListSafe(List<int> numbers)
    {
        bool safe = true;
        bool? increasing = null;

        for (int i = 1; i < numbers.Count(); i++)
        {
            int nr1 = numbers[i - 1];
            int nr2 = numbers[i];

            if (!isValidDifference(nr1, nr2))
            {
                safe = false;
                break;
            }

            if (increasing == null)
            {
                increasing = isIncreasing(nr1, nr2);
            }
            else if (increasing != isIncreasing(nr1, nr2))
            {
                safe = false;
                break;
            }
        }
        return safe;
    }
}