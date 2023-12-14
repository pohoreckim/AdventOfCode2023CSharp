using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_11
{
    internal struct Point2D
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public Point2D(int x, int y)
        {
            X = x;
            Y = y;
        }
        public static bool operator ==(Point2D left, Point2D right) => left.X == right.X && left.Y == right.Y;
        public static bool operator !=(Point2D left, Point2D right) => !(left == right);
        public static int ManhattanDistance (Point2D left, Point2D right) => Math.Abs(left.X - right.X) + Math.Abs(left.Y - right.Y);
    }
}
