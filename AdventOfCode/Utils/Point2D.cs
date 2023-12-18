using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils
{
    public struct Point2D
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public Point2D(int x, int y)
        {
            X = x;
            Y = y;
        }
        public static bool operator ==(Point2D a, Point2D b) => a.X == b.X && a.Y == b.Y;
        public static bool operator !=(Point2D a, Point2D b) => !(a == b);
        public static Point2D operator +(Point2D a, Point2D b) => new Point2D(a.X + b.X, a.Y + b.Y);
        public static int ManhattanDistance(Point2D left, Point2D right) => Math.Abs(left.X - right.X) + Math.Abs(left.Y - right.Y);
    }
}
