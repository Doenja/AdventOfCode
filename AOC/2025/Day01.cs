using AdventOfCodeSupport;

namespace AOC._2025
{
    public class Day01 : AdventBase
    {
        protected override object InternalPart1()
        {
            int dial = 50;
            int answer = 0;

            foreach (var line in Input.Lines)
            {
                char rotation = line[0];
                int distance = int.Parse(line[1..]);

                dial = rotation == 'R' ? dial + distance : dial - distance;

                if (dial % 100 == 0)
                {
                    answer++;
                }
            }

            return answer;
        }

        protected override object InternalPart2()
        {
            int dial = 50;
            int answer = 0;

            foreach (var line in Input.Lines)
            {
                char rotation = line[0];
                int distance = int.Parse(line[1..]);
                int newDial = rotation == 'R' ? dial + distance : dial - distance;

                answer += CountZeroLandOrPass(dial, newDial);
                dial = newDial;
            }

            return answer;
        }


        public static int CountZeroLandOrPass(int start, int end)
        {
            int counter = 0;
            if (end > start)
            {
                // Turning dial to the right
                int startHundred = (int)Math.Ceiling(start / 100.0);
                int endHundred = (int)Math.Ceiling(end / 100.0);

                counter = endHundred - startHundred;
            }
            else
            {
                // Turning dial to the left
                int startHundred = (int)Math.Floor(start / 100.0);
                int endHundred = (int)Math.Floor(end / 100.0);

                counter = startHundred - endHundred;
            }

            // If you start on a hundred or 0, don't count it
            if (start % 100 == 0)
            {
                counter--;
            }

            // If you end on a hundred or 0, count it
            if (end % 100 == 0)
            {
                counter++;
            }

            return counter;
        }
    }
}
