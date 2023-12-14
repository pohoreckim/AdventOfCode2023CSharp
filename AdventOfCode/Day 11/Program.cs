using Day_11;
using Utils;
// Load input

string input = InputLoader.LoadInput();
UniverseMap universe = new UniverseMap(input.Split('\n').SkipLast(1).ToList());

// Part One

ulong result = universe.SumMinDistances(2);
Console.WriteLine($"Part One answear: {result}");

// Part Two

result = universe.SumMinDistances(1_000_000);

Console.WriteLine($"Part Two answear: {result}");