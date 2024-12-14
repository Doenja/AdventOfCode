using AdventOfCodeSupport;
using AOC.Utils;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace AOC._2024
{
    internal class Day06 : AdventBase
    {
        protected override object InternalPart1()
        {
            int answer = 0;

            Grid grid = new Grid(Input.Lines);

            Point guard = grid.FirstOrDefault(p => grid.GetValue(p) == '^' || grid.GetValue(p) == '>' || grid.GetValue(p) == '<' || grid.GetValue(p) == 'v');
            Point direction;
            switch (grid.GetValue(guard))
            {
                case '^':
                    direction = Direction.Top; 
                    break;
                case '>':
                    direction = Direction.Right;
                    break;
                case '<':
                    direction = Direction.Left;
                    break;
                default:
                    direction = Direction.Bot;
                    break;
            }

            // While the guard does not encounter #, step in direction
            Point stepper = new Point(guard.x, guard.y);

            while (true)
            {
                var nextStep = stepper.Add(direction);

                if (!grid.PointExists(nextStep))
                {
                    break;
                }

                if(grid.GetValue(nextStep) == '#')
                {
                    direction = Direction.TurnRight(direction);
                   
                } else if (grid.GetValue(nextStep) == 'X')
                {
                    stepper = nextStep;
  
                } else
                {
                    answer++;
                    stepper = nextStep;
                    grid.SetValue(nextStep, 'X');
                }

            }
            grid.Print();

            return answer;
        }

        protected override object InternalPart2()
        {
            int answer = 0;

          
            return answer;
        }

    }
}
