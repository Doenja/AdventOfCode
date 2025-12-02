using AdventOfCodeSupport;
using System.Numerics;

namespace AOC._2025
{
    public class Day02 : AdventBase
    {
        protected override object InternalPart1()
        {
            BigInteger answer = 0;
            var ranges = Input.Lines[0].Split(',');

            foreach (var range in ranges)
            {
                var parts = range.Split('-');

                string startDigits = parts[0];
                string endDigits = parts[1];

                long startLong = long.Parse(parts[0]);
                long endLong = long.Parse(parts[1]);

                for (int i = startDigits.Length; i < endDigits.Length + 1; i++)
                {
                    // Only numbers with an even amount of digits can be a sequence repeated twice
                    if(i % 2 == 0)
                    {
                        // Generate a number with half the amount of digits i,
                        // Example: i=6, generatedNumberPart = 100 (3 digits)
                        var generatedNumberPart = (long)Math.Pow(10, i / 2 - 1);

                        while (true)
                        {
                            var generated = MakeRepeatedSequence(generatedNumberPart);
                            if (generated > endLong)
                            {
                                break;
                            }
                            if(generated >= startLong)
                            {
                                answer += generated;
                            }

                            generatedNumberPart++;
                        }
                    }
                }

            }
            return answer;
        }

        protected override object InternalPart2()
        {
            int answer = 0;

            return answer;
        }

        public static BigInteger MakeRepeatedSequence(long nr)
        {
            int digits = nr.ToString().Length;
            return nr * (long)Math.Pow(10, digits) + nr;
        }
    }
}
