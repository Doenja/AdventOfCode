using AdventOfCodeSupport;
using AOC.Utils;

namespace AOC._2024
{
    internal class Day06 : AdventBase
    {
        protected override object InternalPart1()
        {
            int answer = 0;

            Grid grid = new Grid(Input.Lines);
            Point guard = getGuard(grid);

            Point stepper = new Point(guard.x, guard.y);
            Point direction = getGuardDirection(grid, guard);

            while (true)
            {
                var nextStep = stepper.Add(direction);

                if (!grid.PointExists(nextStep))
                {
                    break;
                }

                if (grid.GetValue(nextStep) == '#')
                {
                    direction = Direction.TurnRight(direction);
                    continue;
                }
                else if (grid.GetValue(nextStep) == 'X')
                {
                    stepper = nextStep;
                    continue;
                }

                answer++;
                stepper = nextStep;
                grid.SetValue(nextStep, 'X');
            }

            return answer;
        }

        protected override object InternalPart2()
        {
            int answer = 0;

            Grid grid = new Grid(Input.Lines);
            Point guard = getGuard(grid);


            foreach (Point point in grid)
            {
                if (grid.GetValue(point) != '.') continue;

                var checkGrid = new Grid(Input.Lines);
                checkGrid.SetValue(point, '#');

                var unique = new HashSet<string>();

                Point stepper = new Point(guard.x, guard.y);
                Point direction = getGuardDirection(checkGrid, guard);

                while (true)
                {
                    var nextStep = stepper.Add(direction);

                    if (unique.Contains($"{nextStep.x}-{nextStep.y}-{direction}"))
                    {
                        answer++;
                        break;
                    }

                    if (!checkGrid.PointExists(nextStep))
                    {
                        break;
                    }

                    if (checkGrid.GetValue(nextStep) == '#')
                    {
                        direction = Direction.TurnRight(direction);
                        continue;
                    }

                    unique.Add($"{nextStep.x}-{nextStep.y}-{direction}");
                    stepper = nextStep;

                }


            }

            return answer;
        }

        private Point getGuard(Grid grid)
        {
            return grid.FirstOrDefault(p => grid.GetValue(p) == '^' || grid.GetValue(p) == '>' || grid.GetValue(p) == '<' || grid.GetValue(p) == 'v');
        }

        private Point getGuardDirection(Grid grid, Point guard)
        {

            switch (grid.GetValue(guard))
            {
                case '^':
                    return Direction.Top;
                case '>':
                    return Direction.Right;
                case '<':
                    return Direction.Left;
                default:
                    return Direction.Bot;
            }
        }
    }
}
