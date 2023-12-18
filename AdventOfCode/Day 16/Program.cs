using Day_16;
using Utils;
// Load input

string input = InputLoader.LoadInput();
Grid grid = new Grid(input.Trim().Split('\n'));

// Part One

grid.AddBeam(new Beam(new Point2D(-1, 0), Compass.East));
grid.Simulation();
int result = grid.Visited.GroupBy(x => x.Position).Count();
Console.WriteLine($"Part One answear: {result}");

// Part Two

result = 0;
int counter = 0;
for (int i = 0; i < grid.Height; i++)
{
    List<(Point2D point, Point2D dir)> edges = new List<(Point2D, Point2D)>
    {
        (new Point2D(-1, i), Compass.East),
        (new Point2D(grid.Width, i), Compass.West)
    };
    foreach (var edge in edges)
    {
        grid.Reset();
        grid.AddBeam(new Beam(edge.point, edge.dir));
        grid.Simulation();
        result = Math.Max(result, grid.Visited.GroupBy(x => x.Position).Count());
        Console.WriteLine($"Checked {++counter}");
    }
}
for (int i = 0; i < grid.Width; i++)
{
    List<(Point2D point, Point2D dir)> edges = new List<(Point2D, Point2D)>
    {
        (new Point2D(i, -1), Compass.South),
        (new Point2D(i, grid.Height), Compass.North)
    };
    foreach (var edge in edges)
    {
        grid.Reset();
        grid.AddBeam(new Beam(edge.point, edge.dir));
        grid.Simulation();
        result = Math.Max(result, grid.Visited.GroupBy(x => x.Position).Count());
        Console.WriteLine($"Checked {++counter}");
    }
}

Console.WriteLine($"Part Two answear: {result}");