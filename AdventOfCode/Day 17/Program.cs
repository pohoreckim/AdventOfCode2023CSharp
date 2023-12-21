using Day_17;
using Utils;
// Load input

string input = InputLoader.LoadInput();
Map map = new Map(input.Trim().Split('\n'), (1, 3));

// Part One

int result = map.AStar(new Point2D(0, 0), new Point2D(map.Width - 1, map.Height - 1));
Console.WriteLine($"Part One answear: {result}");

// Part Two

map = new Map(input.Trim().Split('\n'), (4, 10));
result = map.AStar(new Point2D(0, 0), new Point2D(map.Width - 1, map.Height - 1)); ;

Console.WriteLine($"Part Two answear: {result}");