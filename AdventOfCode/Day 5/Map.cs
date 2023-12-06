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
    }
}
