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

int result = 0;
foreach (var pattern in patterns)
{
    var mirror = pattern.GetMirrorPossition();
    result += mirror.axis == Axis.Vertical ? mirror.position : 100 * mirror.position; 
}

Console.WriteLine($"Part One answear: {result}");

// Part Two

result = 0;

Console.WriteLine($"Part Two answear: {result}");