using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_14
{
    enum Direction
    {
        North, West, South, East
    }
    internal class Platform
    {
        public const char RoundStone = 'O';
        public const char SquareStone = '#';
        public const char FreeSpace = '.';
        public int Width { get; private set; }
        public int Height { get; private set; }
        public int Weight { get => Rocks.Select(x => Height - x.Y).Sum(); }
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
        public int MoveStones(Point2D vector)
        {
            int movedStonesCount = 0;
            for (int i = 0; i < Rocks.Count; i++)
            {
                bool ifMoved = false;
                while (CanMove(Rocks[i], vector))
                {
                    Place(Rocks[i], FreeSpace);
                    ifMoved = true;
                    Rocks[i] = Rocks[i] + vector;
                    Place(Rocks[i], RoundStone);
                }
                movedStonesCount += ifMoved ? 1 : 0;
            }
            return movedStonesCount;
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
        public int Cycle()
        {
            int movedStonesCount = 0;
            List<Point2D> vectors = new List<Point2D>()
            {
                new Point2D(0, -1),
                new Point2D(-1, 0),
                new Point2D(0, 1),
                new Point2D(1, 0)
            };
            List<Direction> directions = new List<Direction>() { Direction.North, Direction.West, Direction.South, Direction.East };
            foreach (var item in vectors.Zip(directions))
            {
                Sort(item.Second);
                movedStonesCount += MoveStones(item.First);
            }
            return movedStonesCount;
        }
        private void Sort(Direction direction)
        {
            switch (direction)
            {
                case Direction.North:
                    Rocks = Rocks.OrderBy(x => x.Y).ToList();
                    break;
                case Direction.West:
                    Rocks = Rocks.OrderBy(x => x.X).ToList();
                    break;
                case Direction.South:
                    Rocks = Rocks.OrderByDescending(x => x.Y).ToList();
                    break;
                case Direction.East:
                    Rocks = Rocks.OrderByDescending(x => x.X).ToList();
                    break;
                default:
                    break;
            }
        }
    }
}
