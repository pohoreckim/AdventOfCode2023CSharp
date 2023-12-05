using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_4
{
    internal readonly record struct Card(int[] WinningNumbers, int[] PickedNumbers)
    {
        public int[] MatchingNumers => WinningNumbers.Intersect(PickedNumbers).ToArray();
    }
}
