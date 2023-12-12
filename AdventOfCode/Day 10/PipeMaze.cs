using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_10
{
    internal class PipeMaze
    {
        public static readonly char StartChar = 'S';
        public static readonly char FreeTile = '#';
        private readonly char[][] _maze;
        private readonly int[,] _distance;
        public int Width { get; private set; }
        public int Height { get; private set; }
        public int MaxDistance { get { return _distance.Cast<int>().Max(); } }
        public Point2D StartPosition { get; private set; }
        public PipeMaze(string[] lines)
        {
            Height = lines.Length;
            Width = lines[0].Length;
            _maze = new char[Height][];
            _distance = new int[Height, Width];
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    _distance[i, j] = -1;
                }
            }
            for (int i = 0; i < lines.Length; i++)
            {
                _maze[i] = lines[i].ToCharArray();
                if (_maze[i].Contains(StartChar)) StartPosition = new Point2D(_maze[i].ToList().IndexOf(StartChar), i);
            }
        }
        public char GetChar(Point2D position)
        {
            return _maze[position.Y][position.X];
        }
        public void SetChar(char c, Point2D position)
        {
            _maze[position.Y][position.X] = c;
        }
        public bool SetDistance(int value, Point2D position)
        {
            if (_distance[position.Y, position.X] != -1 && _distance[position.Y, position.X] < value) return false;
            _distance[position.Y, position.X] = value;
            return true;
        }
        public override string ToString()
        {
            string result = "";
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    result += _distance[i, j] >= 0 ? _maze[i][j] : FreeTile;
                }
                result += "\n";
            }
            return result;
        }
    }
}
