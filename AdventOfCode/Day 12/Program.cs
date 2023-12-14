using Day_12;
using Utils;
// Load input

string input = InputLoader.LoadInput();

// Part One

ulong result = 0;
foreach (var line in input.Split('\n').SkipLast(1))
{
    var informations = line.Split(" ");
    List<int> lengths = informations[1].Split(",").Select(x => int.Parse(x)).ToList();
    SpringsRow springsRow = new SpringsRow(informations[0] + ".", lengths);
    result += springsRow.FindPossibleSolutions();
}

Console.WriteLine($"Part One answear: {result}");

// Part Two

Func<string, string, int, string> Repeat = (value, separator, times) =>
{
    return string.Join(separator, Enumerable.Repeat(value, times));
};

result = 0;
foreach (var line in input.Split('\n').SkipLast(1))
{
    var informations = line.Split(" ");
    (informations[0], informations[1]) = (Repeat(informations[0], "?", 5) + ".", Repeat(informations[1], ",", 5));
    List<int> lengths = informations[1].Split(",").Select(x => int.Parse(x)).ToList();
    SpringsRow springsRow = new SpringsRow(informations[0], lengths);
    result += springsRow.FindPossibleSolutions();
}

Console.WriteLine($"Part Two answear: {result}");