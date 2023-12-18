using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;

namespace Day_16
{
    internal class Compass
    {
        public static readonly Point2D East = new Point2D(1, 0);
        public static readonly Point2D West = new Point2D(-1, 0);
        public static readonly Point2D North = new Point2D(0, -1);
        public static readonly Point2D South = new Point2D(0, 1);
    }
}
