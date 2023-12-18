using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;

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
        private List<int> GetEmptyColumns()
        {
            List<int> emptyColumnsIds = new List<int>();
            for (int i = 0; i < Width; i++)
            {
                if (GetColumn(i).All(x => x == EmptySpace)) emptyColumnsIds.Add(i);
            }
            return emptyColumnsIds;
        }
        private List<int> GetEmptyRows()
        {
            List<int> emptyRowsIds = new List<int>();
            for (int i = 0; i < Height; i++)
            {
                if (GetRow(i).All(x => x == EmptySpace)) emptyRowsIds.Add(i);
            }
            return emptyRowsIds;
        }
        public ulong SumMinDistances(int emptySpaceMult)
        {
            List<int> emptyRows = GetEmptyRows();
            List<int> emptyColumns = GetEmptyColumns();
            ulong sum = 0;
            for (int i = 0; i < Galaxies.Count; i++)
            {
                for (int j = i + 1; j < Galaxies.Count; j++)
                {
                    sum += Distance(i, j);
                    sum += (ulong)(emptyRows.Where(y => y < Math.Max(Galaxies[i].Y, Galaxies[j].Y) && y > Math.Min(Galaxies[i].Y, Galaxies[j].Y)).Count() * (emptySpaceMult - 1));
                    sum += (ulong)(emptyColumns.Where(x => x < Math.Max(Galaxies[i].X, Galaxies[j].X) && x > Math.Min(Galaxies[i].X, Galaxies[j].X)).Count() * (emptySpaceMult - 1));
                }
            }
            return sum;
        }
        private ulong Distance(int firstGalaxyId,  int secondGalaxyId)
        {
            return (ulong)(Point2D.ManhattanDistance(Galaxies[firstGalaxyId], Galaxies[secondGalaxyId]));
        }
        private List<char> GetRow(int id)
        {
            return _map[id].ToList();
        }
        private List<char> GetColumn(int id)
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
