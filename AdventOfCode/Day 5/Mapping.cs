using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_5
{
    internal readonly record struct Mapping(ulong DestinationRangeStart, ulong SourceRangeStart, ulong RangeLength)
    {
        public ulong MapNumber(ulong number)
        {
            return DestinationRangeStart + (number - SourceRangeStart);
        }
        public bool IsInRange(ulong number)
        {
            return number >= SourceRangeStart && number < SourceRangeStart + RangeLength;
        }
    }
}
