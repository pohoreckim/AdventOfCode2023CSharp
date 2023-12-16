using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_14
{
    internal class Platform
    {
        public const char RoundStone = 'O';
        public const char SquareStone = '#';
        public const char FreeSpace = '.';
        public int Width { get; private set; }
        public int Height { get; private set; }
        private char[,] _board;
        public List<Point2D> Rocks { get; private set; }
        public Platform(string[] lines)
        {
            Width = lines.Length;
            Height = lines[0].Length;
            Rocks = new List<Point2D>();
            _board = new char[Width, Height];
            for (int i = 0; i < Height; i++)
            {
                var line = lines[i].ToCharArray();
                for (int j = 0; j < Width; j++)
                {
                    _board[j, i] = line[j];
                    if (line[j] == RoundStone) { Rocks.Add(new Point2D(j, i)); }
                }
            }
        }
        public void MoveStones(Point2D vector)
        {
            for (int i = 0; i < Rocks.Count; i++)
            {
                while (CanMove(Rocks[i], vector))
                {
                    Place(Rocks[i], FreeSpace);
                    Rocks[i] = Rocks[i] + vector;
                    Place(Rocks[i], RoundStone);
                }
            }
        }
        private bool CanMove(Point2D point, Point2D vector)
        {
            Point2D dest = point + vector;
            return dest.X >= 0 && dest.Y >= 0 && dest.X < Width && dest.Y < Height &&
                _board[point.X + vector.X, point.Y + vector.Y] == FreeSpace;
        }
        private void Place(Point2D stone, char stoneType = RoundStone) 
        {
            Place(stone.X, stone.Y, stoneType);
        }
        private void Place(int x, int y, char stoneType = RoundStone)
        {
            _board[x, y] = stoneType;    
        }
        public override string ToString()
        {
            string result = "";
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    result += _board[j, i];
                }
                result += '\n';
            }
            return result;
        }
    }
}
