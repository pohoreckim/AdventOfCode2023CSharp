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
        public static List<int> SpringsLengths(string springsString)
        {
            int len = 0;
            List<int> springsLen = new List<int>();
            foreach (var springChar in springsString)
            {
                if (springChar == Damaged) len++;
                else if (len > 0)
                {
                    springsLen.Add(len);
                    len = 0;
                }
            }
            if (len > 0) springsLen.Add(len);
            return springsLen;
        }
        public static bool IfListsAreEqual(List<int> firstList, List<int> secondList)
        {
            if (firstList.Count != secondList.Count) return false;
            for (int i = 0; i < firstList.Count; i++)
            {
                if (firstList[i] != secondList[i]) return false;
            }
            return true;
        }
        public static List<int> ListElementWiseDiff(List<int> firstList, List<int> secondList)
        {
            List<int> result = new List<int>();
            for (int i = 0; i < firstList.Count; i++)
            {
                int diff = i < secondList.Count ? firstList[i] - secondList[i] : firstList[i];
                if(diff > 0) result.Add(diff);
            }
            return result;
        }
        public void FindPossibleSolutions()
        {
            Func("", 0);
        }
        private void Func(string currentString, int index)
        {
            if(currentString.Length == _springs.Length)
            {
                if(IfListsAreEqual(SpringsLengths(currentString), _goals)) PossibleSolutions.Add(currentString);
            }
            else
            {
                if (Heuristics(currentString))
                {
                    if (_springs[index] == Unknown)
                    {
                        Func(currentString + Damaged, index + 1);
                        Func(currentString + Operational, index + 1);
                    }
                    else
                    {
                        Func(currentString + _springs[index], index + 1);
                    }
                }
            }
        }
        private bool Heuristics(string s)
        {
            List<int> springLengths = SpringsLengths(s);
            if(springLengths.Count > _goals.Count) return false;
            for (int i = 0; i < springLengths.Count - 1; i++)
            {
                if (springLengths[i] != _goals[i]) return false;
            }
            List<int> elemDiff = ListElementWiseDiff(_goals, springLengths);
            int required = elemDiff.Sum(x => x) + elemDiff.Count - 1;
            int charsLeft = _springs.Length - s.Length;
            if (charsLeft < required) return false;
            return true;
        }
    }
}
