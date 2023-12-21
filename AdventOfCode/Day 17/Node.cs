using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;

namespace Day_17
{
    internal struct Node
    {
        public Point2D Position { get; private set; }
        public Point2D Direction { get; private set; }
        public int CurrentLength { get; private set; }
        public Node(Point2D position, Point2D direction, int len)
        {
            Position = position;
            Direction = direction;
            CurrentLength = len;
        }
    }
}
