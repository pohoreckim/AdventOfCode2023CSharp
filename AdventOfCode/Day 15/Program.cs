using Utils;
// Load input

string input = InputLoader.LoadInput();

// Part One

int result = input.Trim().Split(',').Select(x => x.ToCharArray().Aggregate(0, (a, b) => ((a + b) * 17) % 256)).Sum();

Console.WriteLine($"Part One answear: {result}");

// Part Two

result = 0;

Console.WriteLine($"Part Two answear: {result}");