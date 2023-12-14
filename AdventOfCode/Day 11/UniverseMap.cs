using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_11
{
    internal class UniverseMap
    {
        public const char GalaxyChar = '#';
        public const char EmptySpace = '.';
        char[][] _map;
        public int Width { get; private set; }
        public int Height { get; private set; }
        public List<Point2D> Galaxies { get; private set; }
        public UniverseMap(List<string> lines)
        {
            Height = lines.Count;
            Width = lines[0].Length;
            Galaxies = new List<Point2D>();
            _map = new char[Height][];
            for (int i = 0; i < Height; i++)
            {
                var chars = lines[i].ToCharArray();
                for (int j = 0; j < chars.Length; j++)
                {
                    if (chars[j] == GalaxyChar) Galaxies.Add(new Point2D(j, i));
                }
                _map[i] = chars;
            }
        }
        public List<char> GetRow(int id)
        {
            return _map[id].ToList();
        }
        public List<char> GetColumn(int id)
        {
            List<char> result = new List<char>();
            for (int i = 0; i < Height; i++)
            {
                result.Add(_map[i][id]);
            }
            return result;
        }
    }
}
