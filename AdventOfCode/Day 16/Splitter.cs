using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;

namespace Day_16
{
    internal class Splitter
    {
        private static readonly Dictionary<char, List<Point2D>> _map = new Dictionary<char, List<Point2D>>
        {
            { '|', new List<Point2D> { Compass.North, Compass.South} },
            { '-', new List<Point2D> { Compass.West, Compass.East} }
        };
        public static List<Point2D>? Split(char c, Point2D dir)
        {
            return _map[c].Any(x => x == dir) ? null : _map[c];
        }
    }
}
