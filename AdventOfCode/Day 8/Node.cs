using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_8
{
    internal class Node
    {
        public string Name { get; private set; }
        public Node? Left { get; private set; }
        public Node? Right { get; private set; }
        public Node(string name)
        {
            Name = name;
        }
        public void AddNeighbours(Node left, Node right)
        {
            Left = left;
            Right = right;
        }
    }
}
