using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_3
{
    internal class EngineSchematic
    {
        public int Widht { get; private set; }
        public int Height { get; private set; }
        private char[][] _schematic;
        public EngineSchematic(string schematic)
        {
            var lines = schematic.Split('\n');
            Height = lines.Length;
            Widht = lines[0].Length;
            _schematic = new char[Height][];
            for (int i = 0; i < lines.Length; i++)
            {
                _schematic[i] = lines[i].ToCharArray();
            }
        }
        public (int, int) GetNumber(int y, int x)
        {
            if (IsInHeight(y) && IsInWidth(x) && char.IsNumber(_schematic[y][x]))
            {
                int startPosition = x;
                string result = _schematic[y][x].ToString();
                (int i, int j) = (1, 1);
                while(IsInWidth(x - i) && char.IsNumber(_schematic[y][x - i]))
                {
                    startPosition = x - i;
                    result = _schematic[y][x - i].ToString() + result;
                    i++;
                }
                while(IsInWidth(x + j) && char.IsNumber(_schematic[y][x + j]))
                {
                    result = result + _schematic[y][x + j].ToString();
                    j++;
                }
                return (int.Parse(result), startPosition);

            }
            return (-1, -1);
        }
        public List<HashSet<(int, int, int)>> AdjecentNumbers(char[] symbols)
        {
            List<HashSet<(int, int, int)>> result = new List<HashSet<(int, int, int)>>();
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Widht; j++)
                {
                    foreach (char c in symbols)
                    {
                        if (_schematic[i][j] == c)
                        {
                            HashSet<(int, int, int)> adjecent = new HashSet<(int, int, int)> ();
                            for (int l = -1; l < 2; l++)
                            {
                                for (int m = -1; m < 2; m++)
                                {
                                    (int val, int x) number = GetNumber(i + l, j + m);
                                    if (number != (-1, -1)) adjecent.Add(new (number.val, i + l, number.x));
                                }
                            }
                            result.Add(adjecent);
                        }
                    }
                }
            }
            return result;
        }
        private bool IsInWidth(int x)
        {
            return x >= 0 && x < Widht;
        }
        private bool IsInHeight(int y)
        {
            return y >= 0 && y < Height;
        }

    }
}
