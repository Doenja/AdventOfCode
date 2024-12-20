﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC.Utils
{
    internal static class Direction
    {
        public static Point Top = new Point(0, -1);
        public static Point TopRight = new Point(1, -1);
        public static Point Right = new Point(1, 0);
        public static Point RightBot = new Point(1, 1);
        public static Point Bot = new Point(0, 1);
        public static Point BotLeft = new Point(-1, 1);
        public static Point Left = new Point(-1, 0);
        public static Point LeftTop = new Point(-1, -1);

        public static Point[] All = { Top, TopRight, Right, RightBot, Bot, BotLeft, Left, LeftTop };


        public static Point TurnRight(Point direction)
        {
            if (direction == Direction.Top) return Right;
            else if (direction == Direction.Right) return Bot;
            else if (direction == Direction.Bot) return Left;
            return Top;
        }

        public static Point InverseDirection(Point direction)
        {
            if (direction == Direction.Top) return Bot;
            else if (direction == Direction.Right) return Left;
            else if (direction == Direction.Bot) return Top;
            return Right;
        }

    }
}
