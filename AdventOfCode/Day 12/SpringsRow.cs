using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_12
{
    internal class SpringsRow
    {
        public static char Damaged = '#';
        public static char Operational = '.';
        public static char Unknown = '?';
        private string _springs;
        private List<int> _goals;
        public List<string> PossibleSolutions { get; private set; }
        public SpringsRow(string springs, List<int> goals)
        {
            _springs = springs;
            _goals = goals;
            PossibleSolutions = new List<string>();
        }
        public ulong FindPossibleSolutions()
        {
            List<(int index, int goalIndex, int goalProgress, ulong mult)> queue = new List<(int index, int goalIndex, int goalProgress, ulong mult)>();
            ulong result = 0;
            queue.Add((0, 0, 0, 1));
            while (queue.Count > 0)
            {
                (int index, int goalIndex, int goalProgress, ulong mult) = queue[0];
                queue.RemoveAt(0);
                if (index >= _springs.Length)
                {
                    result += goalIndex >= _goals.Count && goalProgress == 0 ? mult : 0UL;
                    continue;
                }
                if ((goalIndex >= _goals.Count && goalProgress > 0) || (goalIndex < _goals.Count && goalProgress > _goals[goalIndex])) continue;
                List<char> nextMoves = _springs[index] == Unknown ? new List<char> { Damaged, Operational } : new List<char> { _springs[index] };
                foreach (char move in nextMoves)
                {
                    (int, int, int, ulong) posSolution = (0, 0, 0, 1);
                    if (move == Damaged)
                    {
                        posSolution = (index + 1, goalIndex, goalProgress + 1, mult);
                    }
                    else
                    {
                        if (goalProgress > 0)
                        {
                            if (goalIndex < _goals.Count && _goals[goalIndex] == goalProgress)
                            {
                                posSolution = (index + 1, goalIndex + 1, 0, mult);
                            }
                            else
                                continue;
                        }
                        else
                        {
                            posSolution = (index + 1, goalIndex, 0, mult);
                        }
                    }
                    int i = queue.FindIndex(x => x.index == posSolution.Item1 && x.goalIndex == posSolution.Item2 && x.goalProgress == posSolution.Item3);
                    if (i != -1)
                    {
                        queue[i] = (posSolution.Item1, posSolution.Item2, posSolution.Item3, queue[i].mult + mult);
                    }
                    else
                        queue.Add(posSolution);
                }
            }
            return result;
        }
    }
}
