using AdventOfCodeSupport;
using System.Text.RegularExpressions;

namespace AOC._2025
{
    public class Day010 : AdventBase
    {
        protected override object InternalPart1()
        {
            int answer = 0;

            foreach (var line in Input.Lines)
            {
                var m1 = Regex.Matches(line, @"\[(.*?)\]");
                var diagram = m1[0].Groups[1].Value;
                int bits = GetBits(diagram);

                var m2 = Regex.Matches(line, @"\((.*?)\)");
                var buttons = new List<List<int>>();
                foreach (var m in m2)
                {
                    if (m == null) continue;
                    var s = m.ToString();
                    List<int> newButtons = s
                        .Trim('(', ')')
                        .Split(',')
                        .Select(c => int.Parse(c.ToString()))
                        .ToList();

                    buttons.Add(newButtons);
                }
            }

            return answer;
        }


        protected override object InternalPart2()
        {
            int answer = 0;

            return answer;
        }

        public int GetBits(string s)
        {
            int value = 0;
            foreach (var ch in s)
            {
                value <<= 1;
                if (ch == '#')
                    value |= 1;
            }
            return value;
        }


    }
}
