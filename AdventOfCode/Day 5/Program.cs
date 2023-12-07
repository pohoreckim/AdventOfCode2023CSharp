using Day_5;
using System.Text.RegularExpressions;
using Utils;
// Load input

string input = InputLoader.LoadInput();

Dictionary<string, int> categories = new Dictionary<string, int>()
{
    { "seed", 0},
    { "soil", 1 },
    { "fertilizer", 2},
    { "water", 3},
    { "light", 4},
    { "temperature", 5},
    { "humidity", 6},
    { "location", 7}
};

var lines = input.Split('\n');
List<ulong> seeds = lines[0].Split(':')[1].Trim().Split(' ').Select(x => ulong.Parse(x)).ToList();
List<Map> maps = new List<Map>();
List<Mapping> mappings = new List<Mapping>();
(int SourceCategory, int DestinationCategory) = (-1, -1);
foreach (var line in lines.Skip(2))
{
    if(Regex.IsMatch(line, @".*-.*-.*"))
    {
        var tmp =  line.Split(' ')[0].Split('-');
        SourceCategory = categories[tmp[0]];
        DestinationCategory = categories[tmp[2]];
    }
    else if(Regex.IsMatch(line, @"^\d* \d* \d*"))
    {
        var values = line.Split(' ');
        mappings.Add(new Mapping(ulong.Parse(values[0]), ulong.Parse(values[1]), ulong.Parse(values[2])));
    }
    else
    {
        maps.Add(new Map(SourceCategory, DestinationCategory, new List<Mapping>(mappings)));
        mappings.Clear();
    }
}

// Part One

ulong GetValue(ulong seed, int destinationCategory)
{
    int currentCategory = 0;
    ulong value = seed;
    while (currentCategory != destinationCategory)
    {
        var map = maps.Find(x => x.SourceCategory == currentCategory);
        value = map.GetNumber(value);
        currentCategory = map.DestinationCategory;
    }
    return value;
}

ulong result = ulong.MaxValue;
int destinationCategory = categories["location"];
foreach (var seed in seeds)
{
    ulong value = (GetValue(seed, destinationCategory));
    result = Math.Min(result, value);
}

Console.WriteLine($"Part One answear: {result}");

// Part Two

List<Day_5.Range> ranges = new List<Day_5.Range>();
for (int i = 0; i < seeds.Count; i += 2)
{
    ranges.Add(new Day_5.Range(seeds[i], seeds[i] + seeds[i + 1] - 1));
}

int currentCategory = 0;
while (currentCategory != destinationCategory) 
{
    var map = maps.Find(x => x.SourceCategory == currentCategory);
    var k = map.GetRanges(ranges[0]);
    currentCategory = map.DestinationCategory;
}





Console.WriteLine($"Part Two answear: {result}");