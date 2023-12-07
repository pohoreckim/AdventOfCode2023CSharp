using System;
using System.Collections.Generic;
using System.Linq;
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
            List<Range> ranges = new List<Range>();
            foreach(var mapping in Mappings)
            {
                if (mapping.Includes(range))
                {
                    ranges.Add(mapping.MapRange(range));
                }
                else if (mapping.Intersects(range))
                {

                }
            }
            return ranges;
        }
    }
}
