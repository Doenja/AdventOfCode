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
                        // Generate a number with half the amount of digits i
                        var generatedNumberPart = GenerateNumberPart(i / 2);

                        while (true)
                        {
                            var generated = MakeRepeatedSequence(generatedNumberPart, 2);
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
            BigInteger answer = 0;
            var ranges = Input.Lines[0].Split(',');

            foreach (var range in ranges)
            {
                var parts = range.Split('-');

                string startDigits = parts[0];
                string endDigits = parts[1];

                long startLong = long.Parse(parts[0]);
                long endLong = long.Parse(parts[1]);

                var uniqueInvalidIds = new HashSet<BigInteger>();

                for (int i = startDigits.Length; i < endDigits.Length + 1; i++)
                {
                    var divisors = GetDivisors(i);


                    foreach (var divisor in divisors)
                    {
                        if (divisor == 1) continue;

                        var generatedNumberPart = GenerateNumberPart(i / divisor);

                        while (true)
                        {
                            var generated = MakeRepeatedSequence(generatedNumberPart, divisor);
                            if (generated > endLong)
                            {
                                break;
                            }
                            if (generated >= startLong)
                            {
                                uniqueInvalidIds.Add(generated); 
                            }

                            generatedNumberPart++;
                        }

                    }
                }

                foreach (var invalidId in uniqueInvalidIds)
                {
                    answer += invalidId;
                }
            }
            
            return answer;
        }


        // Example: numberOfDigits=6, returns 100000 
        public static long GenerateNumberPart(int numberOfDigits)
        {
            return (long)Math.Pow(10, numberOfDigits - 1);
        }

        public static BigInteger MakeRepeatedSequence(long nr, int times)
        {
            int digits = nr.ToString().Length;
            BigInteger result = 0;
            BigInteger factor = BigInteger.Pow(10, digits);

            for (int i = 0; i < times; i++)
            {
                result = result * factor + nr;
            }

            return result;
        }

        public static List<int> GetDivisors(int n)
        {
            var divisors = new List<int>();

            for (int i = 1; i <= n; i++)
            {
                if (n % i == 0)
                {
                    divisors.Add(i);
                }
            }

            return divisors;
        }
    }
}
