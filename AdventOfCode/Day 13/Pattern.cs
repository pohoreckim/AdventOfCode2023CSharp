using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_13
{
    enum Axis
    {
        Vertical, Horizontal
    }
    internal class Pattern
    {
        public static char AshSign = '.';
        public static char RockSign = '#';
        public int Width { get; private set; }
        public int Height { get; private set; }
        private List<int> _rows = new List<int>();
        private List<int> _cols = new List<int>();
        public Pattern(string[] patternString)
        {
            Height = patternString.Length;
            Width = patternString[0].Length;
            _rows = new List<int>();
            _cols = new List<int>();   
            List<string> columns = Enumerable.Repeat("", Width).ToList();
            foreach (string line in patternString)
            {
                string rowString = line.Replace(AshSign, '0').Replace(RockSign, '1').PadLeft(32, '0');
                _rows.Add(Convert.ToInt32(rowString, 2));
                char[] chars = line.ToCharArray();
                for (int i = 0; i < chars.Length; i++)
                {
                    columns[i] += chars[i] == AshSign ? '0' : '1';
                }
            }
            foreach (string column in columns)
            {
                _cols.Add(Convert.ToInt32(column.PadLeft(32, '0'), 2));
            }
        }
        public (Axis axis, int position) GetMirrorPossition()
        {
            List<List<int>> dims = new List<List<int>>() { _rows, _cols };
            foreach (var dim in dims)
            {
                int position = FindMirror(dim);
                if(position != -1)
                {
                    return (dim == _rows ? Axis.Horizontal : Axis.Vertical, position + 1);
                }
            }
            return (Axis.Vertical, -1);
        }
        private int FindMirror(List<int> list)
        {
            int result = -1;
            for (int i = 0; i < list.Count - 1; i++)
            {
                int j = 0;
                bool breakFlag = false;
                while (i - j >= 0 && i + j < list.Count - 1)
                {
                    if (list[i + 1 + j] != list[i - j])
                    {
                        breakFlag = true; break;
                    }
                    j++;
                }
                if (!breakFlag) return i;
            }
            return result;
        }
    }
}
