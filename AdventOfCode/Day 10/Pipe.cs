using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_10
{
    internal class Pipe
    {
        public Point2D Position { get; private set; }
        private Point2D[] _ends;
        public Pipe(Point2D position, Point2D firstEnd, Point2D secondEnd)
        {
            Position = position;
            _ends = new Point2D[] {position + firstEnd, position + secondEnd };
        }
        public Pipe(Point2D position, (Point2D, Point2D) ends) : this(position, ends.Item1, ends.Item2) { }
        public Point2D ThroughPipe(Point2D from)
        {
            return _ends[0] == from ? _ends[1] : _ends[0];
        }
        public bool EndsWith(Point2D point)
        {
            return _ends.Contains(point);
        }
    }
}
