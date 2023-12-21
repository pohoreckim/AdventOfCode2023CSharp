using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;

namespace Day_17
{
    internal class CostArray
    {
        private readonly Dictionary<Point2D, int> _mapping = new()
        {
            { new Point2D(1, 0), 0 },
            { new Point2D(-1, 0), 1 },
            { new Point2D(0, 1), 2 },
            { new Point2D(0, -1), 3 },
        };
        private int[,,] _costs;
        public int BoardWidth { get; private set; }
        public int BoardHeight { get; private set;}
        public int Directions { get; private set; }
        public int UpperBound { get; private set; }
        public CostArray(int boardWidth, int boardHeight, int upperBound)
        {
            BoardWidth = boardWidth;
            BoardHeight = boardHeight;
            Directions = _mapping.Count;
            UpperBound = upperBound;
            _costs = new int[BoardWidth * BoardHeight, Directions, UpperBound];
            for (int i = 0; i < BoardWidth * BoardHeight; i++)
            {
                for (int j = 0; j < Directions; j++)
                {
                    for (int k = 0; k < UpperBound; k++)
                    {
                        _costs[i, j, k] = int.MaxValue / 2;
                    }
                }
            }
        }
        public int GetValue(Node node)
        {
            return node.CurrentLength == 0 ? 0 : _costs[PointToInt(node.Position), _mapping[node.Direction], node.CurrentLength - 1];
        }
        public void SetValue(Node node, int value)
        {
            _costs[PointToInt(node.Position), _mapping[node.Direction], node.CurrentLength - 1] = value;
        }
        private int PointToInt(Point2D point) => point.Y * BoardWidth + point.X;

    }
}
