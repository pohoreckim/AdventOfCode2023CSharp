using Day_17;
using Utils;
// Load input

string input = InputLoader.LoadInput();
Map map = new Map(input.Trim().Split('\n'), 3);

// Part One

int result = map.AStar(new Point2D(0, 0), new Point2D(map.Height - 1, map.Width - 1));
Console.WriteLine($"Part One answear: {result}");

// Part Two

result = 0;

Console.WriteLine($"Part Two answear: {result}");