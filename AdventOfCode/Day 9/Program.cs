using Utils;
// Load input

string input = InputLoader.LoadInput();
var lines = input.Split('\n').SkipLast(1);

// Part One

long Extrapolate(List<long> sequence)
{
    if (sequence.All(x => x == 0)) return 0;
    List<long> diff = new List<long>();
    sequence.Aggregate((x, y) => { diff.Add(y - x); return y; });
    return Extrapolate(diff) + sequence[sequence.Count - 1];
}

long result = 0;

foreach (var line in lines)
{
    result += Extrapolate(line.Trim().Split(' ').Select(x => long.Parse(x)).ToList());
}

Console.WriteLine($"Part One answear: {result}");

// Part Two

result = 0;

long ExtrapolateBackwards(List<long> sequence)
{
    if (sequence.All(x => x == 0)) return 0;
    List<long> diff = new List<long>();
    sequence.Aggregate((x, y) => { diff.Add(y - x); return y; });
    return sequence[0] - ExtrapolateBackwards(diff);
}

foreach (var line in lines)
{
    result += ExtrapolateBackwards(line.Trim().Split(' ').Select(x => long.Parse(x)).ToList());
}

Console.WriteLine($"Part Two answear: {result}");