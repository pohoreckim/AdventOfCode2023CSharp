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
        public int MaxInLine { get; private set; }
        public Map(string[] lines, int maxInLine)
        {
            Height = lines.Length;
            Width = lines[0].Length;
            MaxInLine = maxInLine;
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
            Node initial = new Node(start, new Point2D(1, 0), 0);
            PriorityQueue<Node, int> open = new();
            Dictionary<Node, int> dist = new() { { initial, 0 } };
            open.Enqueue(initial, 0);
            while (open.Count > 0)
            {
                Node currentNode = open.Dequeue();
                if(currentNode.Position == end)
                {
                    return dist[currentNode];
                }
                foreach (var neighbour in GetNeighbours(currentNode))
                {
                    int newDist = dist[currentNode] + GetValue(neighbour.Position);
                    if (newDist < (dist.ContainsKey(neighbour) ? dist[neighbour] : int.MaxValue / 2))
                    {
                        dist[neighbour] = newDist;
                        
                            open.Enqueue(neighbour, newDist);
                        
                    }
                }
            }
            return -1;
        }
        private List<Node> GetNeighbours(Node node)
        {
            List<Node> result = new List<Node>();
            if (node.CurrentLength < MaxInLine) result.Add(new Node(node.Position + node.Direction, node.Direction, node.CurrentLength + 1));
            List<Point2D> points = node.Direction.X == 0 ?
                new List<Point2D> { new Point2D(1, 0), new Point2D(-1, 0) } :
                new List<Point2D> { new Point2D(0, 1), new Point2D(0, -1) };
            foreach (var point in points)
            {
                result.Add(new Node(node.Position + point, point, 1));
            }
            return result.Where(x => InBounds(x.Position)).ToList();
        }
        private bool InBounds(Point2D p) => p.X >= 0 && p.Y >= 0 && p.X < Width && p.Y < Height; 
    }
}
