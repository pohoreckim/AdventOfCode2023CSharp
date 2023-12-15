using Day_13;
using Utils;
// Load input

string input = InputLoader.LoadInput();
List<Pattern> patterns = new List<Pattern>();
foreach (var patternScheme in input.Split("\n\n"))
{
    patterns.Add(new Pattern(patternScheme.Trim().Split('\n')));
}

// Part One

List<(Axis axis, int position)> mirrors = new List<(Axis axis, int position)>();
foreach (var pattern in patterns)
{
    mirrors.Add(pattern.GetMirrorPossition());
}

int result = 0;
result += mirrors.Select(x => x.axis == Axis.Vertical ? x.position : x.position * 100).Sum();
Console.WriteLine($"Part One answear: {result}");

// Part Two

result = 0;
for (int i = 0; i < patterns.Count; i++)
{
    result += patterns[i].GetMirrorsWithSmudges().Where(x => x != mirrors[i])
        .Select(x => x.axis == Axis.Vertical ? x.position : x.position * 100).Sum();
}

Console.WriteLine($"Part Two answear: {result}");