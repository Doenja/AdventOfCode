using AdventOfCodeSupport;

namespace AOC._2025
{
    public class Day05 : AdventBase
    {
        protected override object InternalPart1()
        {
            long answer = 0;

            var ranges = new List<(long start, long end)>();

            var processingRanges = true;
            foreach (var line in Input.Lines)
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    processingRanges = false;
                    continue;
                }

                if (processingRanges)
                {
                    var start = long.Parse(line.Split('-')[0]);
                    var end = long.Parse(line.Split('-')[1]);

                    var rangesToRemove = new List<(long start, long end)>();
                    foreach (var range in ranges)
                    {
                        if (RangesOverlap(start, end, range.start, range.end))
                        {
                            rangesToRemove.Add(range);
                            start = Math.Min(start, range.start);
                            end = Math.Max(end, range.end);
                        } 
                    }

                    ranges.Add((start, end));

                    foreach (var range in rangesToRemove)
                    {
                        ranges.Remove(range);
                    }
                }
                else
                {
                    // Check if ingredient is in ranges
                    var ingredient = long.Parse(line);
                    foreach (var range in ranges)
                    {
                        if (IsInRange(ingredient, range.start, range.end))
                        {
                            answer++;
                            break;
                        }
                    }

                }
            }

            return answer;
        }

        protected override object InternalPart2()
        {
            long answer = 0;

            var ranges = new List<(long start, long end)>();

            foreach (var line in Input.Lines)
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    break;
                }

                var start = long.Parse(line.Split('-')[0]);
                var end = long.Parse(line.Split('-')[1]);

                var rangesToRemove = new List<(long start, long end)>();
                foreach (var range in ranges)
                {
                    if (RangesOverlap(start, end, range.start, range.end))
                    {
                        start = Math.Min(start, range.start);
                        end = Math.Max(end, range.end);
                        rangesToRemove.Add(range);
                    }
                }

                ranges.Add((start, end));

                foreach (var range in rangesToRemove)
                {
                    ranges.Remove(range);
                }
            }

            foreach(var range in ranges)
            {
                answer += range.end - range.start + 1;
            }

            return answer;
        }

      
        public static bool RangesOverlap(long start1, long end1, long start2, long end2)
        {
            return start1 <= end2 && start2 <= end1;
        }

        public static bool IsInRange(long number, long rangeStart, long rangeEnd)
        {
            return number >= rangeStart && number <= rangeEnd;
        }

    }
}
