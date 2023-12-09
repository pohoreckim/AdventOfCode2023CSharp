using Utils;
// Load input

string input = InputLoader.LoadInput();
var lines = input.Split('\n').SkipLast(1);

// Part One

long Func(List<long> sequence)
{
    if (sequence.All(x => x == 0)) return 0;
    List<long> diff = new List<long>();
    sequence.Aggregate((x, y) => { diff.Add(y - x); return y; });
    return Func(diff) + sequence[sequence.Count - 1];
}

long result = 0;

foreach (var line in lines)
{
    result += Func(line.Trim().Split(' ').Select(x => long.Parse(x)).ToList());
}

Console.WriteLine($"Part One answear: {result}");

// Part Two

Console.WriteLine($"Part Two answear: {result}");