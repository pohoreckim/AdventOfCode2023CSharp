using Day_14;
using Utils;
// Load input

string input = InputLoader.LoadInput();

// Part One

int result = 0;
Platform platform = new Platform(input.Trim().Split('\n'));
//Console.WriteLine(platform.ToString());
platform.MoveStones(new Point2D(0, -1));
//Console.WriteLine();
//Console.WriteLine(platform.ToString());
result += platform.Rocks.Select(x => platform.Height - x.Y).Sum();
Console.WriteLine($"Part One answear: {result}");

// Part Two

result = 0;

Console.WriteLine($"Part Two answear: {result}");