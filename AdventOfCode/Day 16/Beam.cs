using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;

namespace Day_16
{
    internal class Beam
    {
        public Point2D Position { get; private set; }
        public Point2D Direction { get; private set; }
        public Beam(Point2D position, Point2D direction)
        {
            Position = position;
            Direction = direction;
        }
        public void MakeMove()
        {
            Position += Direction;
        }
        public void ChangeDirection(Point2D direction)
        {
            Direction = direction;
        }
        public Beam Clone()
        {
            return new Beam(Position, Direction);
        }
        public static bool operator ==(Beam a, Beam b) => a.Position == b.Position && a.Direction == b.Direction;
        public static bool operator !=(Beam a, Beam b) => !(a == b);
    }
}
