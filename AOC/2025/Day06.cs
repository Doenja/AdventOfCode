using AdventOfCodeSupport;
using System.Text.RegularExpressions;

namespace AOC._2025
{
    public class Day06 : AdventBase
    {
        protected override object InternalPart1()
        {
            long answer = 0;
            Dictionary<int, List<int>> numberCols = new();

            foreach (var line in Input.Lines)
            {
                var split = Regex.Split(line.Trim(), @"\s+");
                for (int i = 0; i < split.Length; i++)
                {
                    if (split[i] == "*")
                    {
                        answer += MultiplyAllNumbers(numberCols[i]);
                        continue;
                    }

                    if (split[i] == "+")
                    {
                        answer += AddAllNumbers(numberCols[i]);
                        continue;
                    }

                    if (int.TryParse(split[i], out int nr))
                    {
                        if (!numberCols.ContainsKey(i))
                        {
                            numberCols[i] = new List<int>();
                        }
                        numberCols[i].Add(nr);
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
            var stringCols = new Dictionary<int, List<string>>();

            for (int i = 0; i < height; i++)
            {
                for (int j = width - 1; j >= 0; j--)
                {
                    var ch = Input.Lines[i][j];

                    if (int.TryParse(ch.ToString(), out int nr))
                    {
                        if (!stringCols.ContainsKey(j))
                        {
                            stringCols[j] = new List<string>();
                        }
                        stringCols[j].Add(ch.ToString());
                    }
                }
            }

            var numbers = new List<int>();

            for (int j = width - 1; j >= 0; j--)
            {
                if (stringCols.ContainsKey(j))
                {
                    var currentNumber = int.Parse(string.Join("", stringCols[j]));
                    numbers.Add(currentNumber);
                }

                char bottomChar = Input.Lines[height - 1][j];
                if (bottomChar == '+')
                {
                    answer += AddAllNumbers(numbers);
                    numbers.Clear();
                    continue;
                }
                if (bottomChar == '*')
                {
                    answer += MultiplyAllNumbers(numbers);
                    numbers.Clear();
                    continue;
                }
            }
            return answer;
        }


        public long MultiplyAllNumbers(List<int> numbers)
        {
            return numbers.Aggregate(1L, (acc, val) => acc * val);
        }

        public long AddAllNumbers(List<int> numbers)
        {
            return numbers.Aggregate(0L, (acc, val) => acc + val);
        }
    }
}
