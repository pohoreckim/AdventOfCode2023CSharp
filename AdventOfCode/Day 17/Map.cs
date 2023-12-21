using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Utils;

namespace Day_17
{
    internal class Map
    {
        private int[,] _heatLoss;
        public int Width { get; private set; }
        public int Height { get; private set; }
        public int GetValue(Point2D point) { return _heatLoss[point.Y, point.X]; }
        public (int Min, int Max) Bounds{ get; private set; }
        public Map(string[] lines, (int, int) bounds)
        {
            Height = lines.Length;
            Width = lines[0].Length;
            Bounds = bounds;
            _heatLoss = new int[Height, Width];
            for (int i = 0; i < Height; i++)
            {
                var line = lines[i].ToCharArray();
                for (int j = 0; j < line.Length; j++)
                {
                    _heatLoss[i, j] = int.Parse(line[j].ToString());
                }
            }
        }
        public int AStar(Point2D start, Point2D end)
        {
            CostArray dist = new CostArray(Width, Height, Bounds.Max);
            var neighbouring = GetAllNeighbours(start);
            PriorityQueue<Node, int> open = new();
            List<Node> initials = neighbouring.Select(x => new Node(start + x, x, 1)).ToList();
            initials.ForEach(x => { dist.SetValue(x, GetValue(x.Position)); open.Enqueue(x, GetValue(x.Position)); });  
            while (open.Count > 0)
              {
                Node currentNode = open.Dequeue();
                if(currentNode.Position == end && currentNode.CurrentLength >= Bounds.Min)
                {
                    return dist.GetValue(currentNode);
                }
                foreach (var neighbour in GetNeighbours(currentNode))
                {
                    int newDist = dist.GetValue(currentNode) + GetValue(neighbour.Position);
                    if (newDist < dist.GetValue(neighbour))
                    {
                        dist.SetValue(neighbour, newDist);
                        open.Enqueue(neighbour, newDist);
                    }
                }
            }
            return -1;
        }
        private List<Node> GetNeighbours(Node node)
        {
            List<Node> result = new List<Node>();
            if (node.CurrentLength < Bounds.Max) result.Add(new Node(node.Position + node.Direction, node.Direction, node.CurrentLength + 1));
            if (node.CurrentLength >= Bounds.Min)
            {
                List<Point2D> points = node.Direction.X == 0 ?
                    new List<Point2D> { new Point2D(1, 0), new Point2D(-1, 0) } :
                    new List<Point2D> { new Point2D(0, 1), new Point2D(0, -1) };
                foreach (var point in points)
                {
                    result.Add(new Node(node.Position + point, point, 1));
                }
            }
            return result.Where(x => InBounds(x.Position)).ToList();
        }
        private List<Point2D> GetAllNeighbours(Point2D point)
        {
            List<Point2D> aspiringPositions = new List<Point2D>()
            {
                point + new Point2D(1,0),
                point + new Point2D(0,1),
                point + new Point2D(-1,0),
                point + new Point2D(0,-1)
            };
            return aspiringPositions.Where(x => InBounds(x)).ToList();
        }
        private bool InBounds(Point2D p) => p.X >= 0 && p.Y >= 0 && p.X < Width && p.Y < Height; 
    }
}
