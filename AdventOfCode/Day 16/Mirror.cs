using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Utils;

namespace Day_16
{
    internal class Mirror
    {
        private static readonly Dictionary<(char, Point2D), Point2D> _map = new Dictionary<(char, Point2D), Point2D>
        {
            { ('/', Compass.East), Compass.North },
            { ('/', Compass.South), Compass.West },
            { ('/', Compass.North), Compass.East },
            { ('/', Compass.West), Compass.South },
            { ('\\', Compass.West), Compass.North },
            { ('\\', Compass.North), Compass.West },
            { ('\\', Compass.South), Compass.East },
            { ('\\', Compass.East), Compass.South },
        };
        public static Point2D Reflect(char c, Point2D dir)
        {
            return _map[(c , dir)];
        }
    }
}
