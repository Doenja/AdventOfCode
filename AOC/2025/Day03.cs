using AdventOfCodeSupport;
using System.Numerics;

namespace AOC._2025
{
    public class Day03 : AdventBase
    {
        protected override object InternalPart1()
        {
            int answer = 0;

            foreach(var line in Input.Lines)
            {
                int firstNr = 0;
                int startingIndex = 0;
                int secondNr = 0;
        

                for (int i = 0; i < line.Length; i++)
                {
                    var nr = int.Parse(line[i].ToString());
                    if(i == line.Length -1)
                    {
                        secondNr = nr;
                        break;
                    }

                    if (nr > firstNr)
                    {
                        firstNr = nr;
                        startingIndex =  i;
                    }
                }

                for (int i = startingIndex; i < line.Length; i++)
                {
                    if(i == startingIndex)
                    {
                        continue;
                    }
                    var nr = int.Parse(line[i].ToString());
                    if (nr > secondNr)
                    {
                        secondNr = nr;
                    }
                }

                answer += firstNr * 10 + secondNr;

            }
            
            return answer;
        }

        protected override object InternalPart2()
        {
            int answer = 0;
                       
            return answer;
        }

    }
}
