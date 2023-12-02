using System.Text.RegularExpressions;
using Utils;

// Load input

string input = InputLoader.LoadInput();

// Part One

Dictionary<string, int> colorMapping = new Dictionary<string, int>()
{
    { "red", 0 },
    { "green", 1 },
    { "blue", 2 }
};

int[] maxValues = new int[] { 12, 13, 14 };
List<int> gamesIds = new List<int>();
foreach (var line in input.Split('\n').SkipLast(1))
{
    var record = line.Split(':');
    int gameId = int.Parse(Regex.Match(record[0], @"\d+").Groups[0].Value);
    bool breakFlag = false;
    foreach (var set in record[1].Split(";"))
    {
        var reveals = set.Split(",");
        foreach (var reveal in reveals)
        {
            var tokens = reveal.Trim().Split(' ');
            if (int.Parse(tokens[0]) > maxValues[colorMapping[tokens[1]]])
            {
                breakFlag = true;
            }
        }
        if (breakFlag) break;
    }
    if (!breakFlag) gamesIds.Add(gameId);
}

int result = gamesIds.Sum();


Console.WriteLine($"Part One answear: {result}");

// Part Two

List<(int id, int r, int g, int b)> Games = new List<(int, int, int, int)>();
foreach (var line in input.Split('\n').SkipLast(1))
{
    var record = line.Split(':');
    int gameId = int.Parse(Regex.Match(record[0], @"\d+").Groups[0].Value);
    int[] values = new int[] { 0, 0, 0 };
    foreach (var set in record[1].Split(";"))
    {
        var reveals = set.Split(",");
        foreach (var reveal in reveals)
        {
            var tokens = reveal.Trim().Split(' ');
            values[colorMapping[tokens[1]]] = Math.Max(values[colorMapping[tokens[1]]], int.Parse(tokens[0]));
        }
    }
    Games.Add(new(gameId, values[0], values[1], values[2]));
}

result = Games.Select(x => x.r * x.g * x.b).Sum();

Console.WriteLine($"Part Two answear: {result}");