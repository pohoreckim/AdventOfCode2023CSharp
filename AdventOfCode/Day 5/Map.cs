using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace Day_5
{
    internal readonly record struct Map(int SourceCategory, int DestinationCategory, List<Mapping> Mappings)
    {
        public ulong GetNumber(ulong number)
        {
            int id = Mappings.FindIndex(x => x.IsInRange(number));
            if (id >= 0)
            {
                return Mappings[id].MapNumber(number);
            }
            return number;
        }
        public List<Range> GetRanges(Range range) 
        {
            List<Range> result = new List<Range>();
            Queue<Range> ranges = new Queue<Range>();
            ranges.Enqueue(range);
            while (ranges.Count > 0)
            {
                Range currentRange = ranges.Dequeue();
                bool added = false;
                foreach (var mapping in Mappings)
                {
                    if (mapping.Intersects(currentRange))
                    {
                        ulong from = currentRange.Start;
                        ulong to = currentRange.End;
                        if(currentRange.Start < mapping.SourceRangeStart)
                        {
                            from = mapping.SourceRangeStart;
                            ranges.Enqueue(new Range(currentRange.Start, from - 1));
                        }
                        if(currentRange.End > mapping.SourceRangeStart + mapping.RangeLength - 1)
                        {
                            to = mapping.SourceRangeStart - 1 + mapping.RangeLength;
                            ranges.Enqueue(new Range(to + 1, currentRange.End));
                        }
                        result.Add(mapping.MapRange(new Range(from, to)));
                        added = true;
                        break;
                    }
                }
                if (!added) result.Add(currentRange);
            }
            return result;
        }
    }
}
