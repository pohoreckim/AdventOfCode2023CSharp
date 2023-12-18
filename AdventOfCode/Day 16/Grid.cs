using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;

namespace Day_16
{
    internal class Grid
    {
        public static readonly char[] MirrorChars =  { '/', '\\'};
        public static readonly char[] SplitterChar = { '-', '|' };
        private char[,] _layout;
        public List<Beam> Visited;
        public int Height { get; private set; }
        public int Width { get; private set; }
        private List<Beam> _beams;
        public Grid(string[] lines)
        {
            Height = lines.Length;
            Width = lines[0].Length;
            _layout = new char[Height, Width];
            Visited = new List<Beam>();
            _beams = new List<Beam>();
            for (int i = 0; i < Height; i++)
            {
                var line = lines[i].ToCharArray();
                for (int j = 0; j < line.Length; j++)
                {
                    _layout[i, j] = line[j];
                }
            }
        }
        public void Simulation()
        {
            while (_beams.Count > 0)
            {
                for (int i = _beams.Count - 1; i >= 0; i--)
                {
                    _beams[i].MakeMove();
                    if (ShouldStop(_beams[i]))
                    {
                        _beams.RemoveAt(i);
                        
                    }
                    else if (OnMirror(_beams[i].Position))
                    {
                        var position = _beams[i].Position;
                        _beams[i].ChangeDirection(Mirror.Reflect(GetChar(position), _beams[i].Direction));
                    }
                    else if (OnSplitter(_beams[i].Position))
                    {
                        Point2D position = _beams[i].Position;
                        var directions = Splitter.Split(GetChar(position), _beams[i].Direction);
                        if (directions != null)
                        {
                            _beams.RemoveAt(i);
                            foreach (var direction in directions) _beams.Add(new Beam(position, direction));
                        }
                    }
                }
            }
        }
        private char GetChar(Point2D position)
        {
            return _layout[position.Y, position.X];
        }
        private bool IfVisited(Beam beam)
        {
            bool ifContains = Visited.Any(x => x ==  beam);
            if (!ifContains) Visited.Add(beam.Clone());
            return ifContains;
        }
        private bool OnMirror(Point2D point)
        {
            return MirrorChars.Any(x => x == GetChar(point));
        }
        private bool OnSplitter(Point2D point)
        {
            return SplitterChar.Any(x => x == GetChar(point));
        }
        private bool ShouldStop(Beam beam)
        {
            return !InBounds(beam.Position) || IfVisited(beam);
        }
        private bool InBounds(Point2D point)
        {
            return point.X >= 0 && point.Y >= 0 && point.X < Width && point.Y < Height;
        }
        public void AddBeam(Beam beam)
        {
            _beams.Add(beam);
        }
    }
}
