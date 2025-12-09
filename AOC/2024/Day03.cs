using AdventOfCodeSupport;
using System.Text.RegularExpressions;


// 78965138 :(

namespace AOC._2024
{
    internal class Day03 : AdventBase
    {

        Regex mulRegex = new Regex(@"mul\(\d{1,3},\d{1,3}\)");
        Regex mulDoDontRegex = new Regex(@"(mul\(\d{1,3},\d{1,3}\))|(do\(\))|(don\'t\(\))");
        Regex digitRegex = new Regex(@"\d+");

        protected override object InternalPart1()
        {
            int answer = 0;
            string lines = string.Join("", Input.Lines);

            MatchCollection matches = mulRegex.Matches(lines);

            foreach (Match match in matches)
            {
                answer += matchParseAndMultiply(match.Value);
            }

            return answer;
        }

        protected override object InternalPart2()
        {
            int answer = 0;
            string lines = string.Join("", Input.Lines);

            MatchCollection matches = mulDoDontRegex.Matches(lines);

            bool enabled = true;
            foreach (Match match in matches)
            {
                switch (match.Value)
                {
                    case "do()":
                        enabled = true;
                        break;
                    case "don't()":
                        enabled = false;
                        break;
                    default:
                        if (enabled) answer += matchParseAndMultiply(match.Value);
                        break;
                }
            }

            return answer;
        }

        private int matchParseAndMultiply(string stringWithNumbers)
        {
            MatchCollection digits = digitRegex.Matches(stringWithNumbers);
            int product = 1;

            foreach (Match digit in digits)
            {
                int nr;
                bool parsed = int.TryParse(digit.Value, out nr);
                if (parsed) product = product * nr;
            }

            return product;
        }
    }
}
