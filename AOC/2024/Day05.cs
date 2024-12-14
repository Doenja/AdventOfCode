using AdventOfCodeSupport;
using AOC.Utils;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace AOC._2024
{
    internal class Day05 : AdventBase
    {
        private List<string> _invalidUpdates = new List<string>();
        private HashSet<string> _rules = new HashSet<string>();
        protected override object InternalPart1()
        {
            int answer = 0;

            // Split the input
            var i = Array.IndexOf(Input.Lines, "");

            var firstPart = new string[i];
            Array.ConstrainedCopy(Input.Lines, 0, firstPart, 0, firstPart.Length);
            _rules = new HashSet<string>(firstPart);

            var updates = new string[Input.Lines.Length - i - 1];
            Array.ConstrainedCopy(Input.Lines, i + 1, updates, 0, updates.Length);

            // Compare each number to the ones on its left an check for rule violations
            foreach ( var update in updates )
            {
                bool isValid = true;
                List<string> leftFromNr = new List<string>();
                foreach (var nr in update.Split(","))
                {
                    foreach (var lnr in leftFromNr) 
                    {
                        var checkForRule = $"{nr}|{lnr}";
                        if (_rules.Contains(checkForRule))
                        {
                            isValid = false;
                            break;
                        }
                    }
                    leftFromNr.Add(nr);  
                }

                // Find all middle numbers from the valid rules and add them
                if (isValid)
                {
                    answer += GetMidNr(update.Split(","));
                } else
                {
                    _invalidUpdates.Add(update);
                }
                
            }
            return answer;
        }

        protected override object InternalPart2()
        {
            int answer = 0;

            // Sort invalid updates
            var sorted = _invalidUpdates.Select(u =>
            {
                var split = u.Split(",").ToList();
                split.Sort((string x, string y) =>
                {
                    if (x == y) return 0;
                    else if (_rules.Contains($"{x}|{y}")) return -1;
                    else return 1;
                });
                return split;
            }).ToList();
          
            foreach ( var line in sorted )
            {
               answer += GetMidNr(line.ToArray());
            }
            return answer;
        }

        private int GetMidNr(string[] nrString)
        {
            double half = nrString.Length / 2;
            int i = (int)Math.Round(half);
            int nr;
            int.TryParse(nrString[i].ToString(), out nr);
            return nr;
        }
    }
}
