using AdventOfCodeSupport;
using AOC.Utils;

namespace AOC._2024
{
    internal class Day04 : AdventBase
    {
        protected override object InternalPart1()
        {
            int answer = 0;

            var grid = new Grid(Input.Lines);
            string word = "XMAS";

            foreach (Point point in grid) 
            {
                // Skip all points where the value is not X
                if (grid.GetValue(point) != word[0]) continue;

                // If it is X, check in which direction(s) the M is
                var possibleDirections = from d in Direction.All
                                                     where grid.CheckNeighbourValue(point, d, word[1])
                                                     select d;

                foreach (var pd in possibleDirections)
                {
                    Point walkingPoint = new Point(point.x, point.y);
                    bool isValid = true;

                    for (int j = 1; j < word.Length; j++)
                    {
                        walkingPoint = walkingPoint.Add(pd);

                        if (grid.GetValue(walkingPoint) != word[j])
                        {
                            isValid = false;
                            break;
                        };
                    }
                    if (isValid) answer++;
                }
                                    
            }

            return answer;
        }



        protected override object InternalPart2()
        {
            int answer = 0;
            Grid grid = new Grid(Input.Lines);

            foreach (Point point in grid) 
            {
                if (grid.GetValue(point) != 'A') continue;

                string diagonal1 = $"{grid.GetValue(point.Add(Direction.LeftTop))}A{grid.GetValue(point.Add(Direction.RightBot))}";
                string diagonal2 = $"{grid.GetValue(point.Add(Direction.BotLeft))}A{grid.GetValue(point.Add(Direction.TopRight))}";

                if ((diagonal1 == "MAS" || diagonal1 == "SAM") && (diagonal2 == "MAS" || diagonal2 == "SAM"))
                {
                    answer++;
                }
            }

            return answer;
        }
    }
}
