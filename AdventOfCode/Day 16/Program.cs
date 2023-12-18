using Day_16;
using Utils;
// Load input

string input = InputLoader.LoadInput();

// Part One

;
Grid grid = new Grid(input.Trim().Split('\n'));
grid.AddBeam(new Beam(new Point2D(-1, 0), new Point2D(1, 0)));
grid.Simulation();
int result = grid.Visited.GroupBy(x => x.Position).Count();
Console.WriteLine($"Part One answear: {result}");

// Part Two

result = 0;

Console.WriteLine($"Part Two answear: {result}");