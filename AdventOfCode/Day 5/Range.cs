using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_5
{
    internal readonly record struct Range(ulong Start, ulong End)
    {
        private bool Includes(Range other)
        {
            return Start <= other.Start && End >= other.End;
        }
        private bool Intersects(Range other)
        {
            return other.Start <= End && Start <= other.End;
        }
    }
}
